using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PKCode.PresentationFramework.Charts
{
    /// <summary>
    /// Interaction logic for Chart.xaml
    /// </summary>
    public partial class Chart : UserControl
    {
        public Chart()
        {
            InitializeComponent();
            DataPointStringFormat = "{0} ({1:0.00})";
            AxisLabelStringFormat = "{0:0.00}";
        }


        #region Dependency

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            "ItemsSource", typeof(IEnumerable), typeof(Chart),
            new FrameworkPropertyMetadata(default(IEnumerable), FrameworkPropertyMetadataOptions.None,
                OnItemsSourceChanged));

        public static readonly DependencyProperty DisplayPropertyProperty = DependencyProperty.Register(
            "DisplayProperty", typeof(string), typeof(Chart), new PropertyMetadata("Name"));

        public static readonly DependencyProperty ValuePropertyProperty = DependencyProperty.Register(
            "ValueProperty", typeof(string), typeof(Chart), new PropertyMetadata("Value"));

        public static readonly DependencyProperty SerieNamePropertyProperty = DependencyProperty.Register(
            "SerieNameProperty", typeof(string), typeof(Chart), new PropertyMetadata("Description"));

        public static readonly DependencyProperty SerieDataPropertyProperty = DependencyProperty.Register(
            "SerieDataProperty", typeof(string), typeof(Chart), new PropertyMetadata("Items"));

        public static readonly DependencyProperty ChartTitlePropery = DependencyProperty.Register(
            "ChartTitle", typeof(string), typeof(Chart),
            new FrameworkPropertyMetadata("Chart title", FrameworkPropertyMetadataOptions.None, OnTitleChanged));

        public static readonly DependencyProperty ConverterProperty = DependencyProperty.Register(
            "Converter", typeof(IMultiValueConverter), typeof(Chart), new PropertyMetadata(default(IMultiValueConverter)));

        public static readonly DependencyProperty SelectedBrushProperty =
            DependencyProperty.Register("SelectedBrush",
                typeof(Brush), typeof(Chart), new PropertyMetadata(new SolidColorBrush(Colors.Orange)));

        public static readonly DependencyProperty AxisLabelDisplayConverterProperty = DependencyProperty.Register(
            "AxisLabelDisplayConverter", typeof(IValueConverter), typeof(Chart), new PropertyMetadata(default(IValueConverter)));

        public static readonly DependencyProperty ChartTypeProperty = DependencyProperty.Register(
            "ChartType", typeof(ChartType), typeof(Chart), new PropertyMetadata(ChartType.Line));


        #endregion

        #region Properties

        public string SerieDataProperty
        {
            get { return (string)GetValue(SerieDataPropertyProperty); }
            set { SetValue(SerieDataPropertyProperty, value); }
        }
        public string SerieNameProperty
        {
            get { return (string)GetValue(SerieNamePropertyProperty); }
            set { SetValue(SerieNamePropertyProperty, value); }
        }
        public string ValueProperty
        {
            get { return (string)GetValue(ValuePropertyProperty); }
            set { SetValue(ValuePropertyProperty, value); }
        }
        public string DisplayProperty
        {
            get { return (string)GetValue(DisplayPropertyProperty); }
            set { SetValue(DisplayPropertyProperty, value); }
        }

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }
        public string ChartTitle
        {
            get { return (string)GetValue(ChartTitlePropery); }
            set { SetValue(ChartTitlePropery, value); }
        }
        public IMultiValueConverter Converter
        {
            get { return (IMultiValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }
        public IValueConverter AxisLabelDisplayConverter
        {
            get { return (IValueConverter)GetValue(AxisLabelDisplayConverterProperty); }
            set { SetValue(AxisLabelDisplayConverterProperty, value); }
        }
        public Brush SelectedBrush
        {
            get { return (Brush)GetValue(SelectedBrushProperty); }
            set { SetValue(SelectedBrushProperty, value); }
        }
        public ChartType ChartType
        {
            get { return (ChartType)GetValue(ChartTypeProperty); }
            set { SetValue(ChartTypeProperty, value); }
        }


        public bool ShowItems { get; set; }
        public string DataPointStringFormat { get; set; }
        public string AxisLabelStringFormat { get; set; }
        public double? MinimalValue { get; set; }
        public double? MaximalValue { get; set; }

        private IList<ChartSerie> chartSeries;
        private const double EllipseWidth = 6;
        private const double Radious = EllipseWidth / 2;

        private readonly Brush[] brushes =
        {
            new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x82, 0x99)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0xAC, 0x19, 0x3D)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x26, 0x72, 0xEC)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x8A, 0x00)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x09, 0x4A, 0xB2)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x51, 0x33, 0xAB)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0xD2, 0x47, 0x26)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x8C, 0x00, 0x95)),

            new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xA0, 0xB1)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0xBF, 0x1E, 0x4B)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x2E, 0x8D, 0xEF)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0xA6, 0x00)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x0A, 0x5B, 0xC4)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0x64, 0x3E, 0xBF)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0xDC, 0x57, 0x2E)),
            new SolidColorBrush(Color.FromArgb(0xFF, 0xA7, 0x00, 0xAE))
        };
        #endregion

        #region Methods

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Chart;
            control.chartSeries = Convert(e.NewValue as IEnumerable, control.SerieNameProperty,
                control.SerieDataProperty, control.DisplayProperty, control.ValueProperty);
            control.SetData(control.chartSeries);
        }
        private static void OnTitleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Chart;
            control.TitleTextBox.Text = e.NewValue as string;
            control.TitleTextBox.Visibility = string.IsNullOrEmpty(control.TitleTextBox.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
        private void SetData(IEnumerable<ChartSerie> series)
        {
            ChartArea.Children.Clear();
            SetLabels(null, null);
            if (series == null || !series.Any()) return;
            var i = 0;

            var maxValue = 0d;
            var minValue = 0d;
            var maxCount = 0;
            try
            {
                maxValue = series.Max(d => d.Values.Max(y => y.Value));
                minValue = series.Min(d => d.Values.Min(y => y.Value));
                maxCount = series.Max(d => d.Values.Count);
            }
            catch { }

            MinimalValue = MinimalValue ?? minValue - 1;
            MaximalValue = MaximalValue == null || MaximalValue < maxValue ? maxValue + 1 : MaximalValue;

            AddBackgroundSerie(maxCount);
            foreach (var serie in series)
            {
                if (ChartType != ChartType.Point)
                {
                    var partData = CreatePath(serie, maxCount);
                    var path = new Path
                    {
                        Data = Geometry.Parse(partData),
                        ToolTip = serie.Name,
                        Stroke = GetBrush(i),
                        StrokeThickness = 2,
                        Fill = ChartType == ChartType.Area ? GetBrush(i) : Brushes.Transparent,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Visibility = Visibility.Visible
                    };
                    ChartArea.Children.Add(path);
                }
                if (ShowItems || ChartType == ChartType.Point)
                {
                    var points = CreateDataPoints(serie, GetBrush(i), maxCount);
                    foreach (var p in points) ChartArea.Children.Add(p);
                }
                i++;
            }
            SetLabels(MaximalValue, MinimalValue);
        }
        private string CreatePath(ChartSerie serie, double maxItemsCount)
        {
            var builder = new StringBuilder();
            if (maxItemsCount == 0) maxItemsCount = 1;
            for (var i = 0; i < serie.Values.Count; i++)
            {
                var x = (i * ChartArea.ActualWidth) / maxItemsCount;
                var y = (ChartArea.ActualHeight * (1 - serie.Values[i].Value / MaximalValue.Value));
                builder.AppendFormat(i == 0 ? " M {0:0.00} {1:0.00} " : " L {0:0.00} {1:0.00} ", x, y);
            }
            if (ChartType == ChartType.Area)
                builder.AppendFormat("V {0:0.00} H {1:0.00} Z", ChartArea.ActualHeight, (1 / MaximalValue.Value));
            return builder.ToString().Replace(",", ".");
        }
        private IEnumerable<Ellipse> CreateDataPoints(ChartSerie serie, Brush serieBrush, double maxItemsCount)
        {
            var list = new List<Ellipse>();
            for (var i = 0; i < serie.Values.Count; i++)
            {
                var x = (i * ChartArea.ActualWidth) / maxItemsCount;
                var y = (ChartArea.ActualHeight * (1 - serie.Values[i].Value / MaximalValue.Value));

                list.Add(new Ellipse
                {
                    Width = EllipseWidth,
                    Height = EllipseWidth,
                    Fill = serieBrush,
                    Margin = new Thickness(x - Radious, y - Radious, (ChartArea.ActualWidth - x - Radious), (ChartArea.ActualHeight - y - Radious)),
                    ToolTip = Converter != null
                            ? Converter.Convert(new object[] { serie.Values[i].Name, serie.Values[i].Value }, null, null, null) as string
                            : string.Format(DataPointStringFormat, serie.Values[i].Name, serie.Values[i].Value),
                    Opacity = 1
                });
            }
            return list;
        }
        private void SetLabels(double? maxValue, double? minValue)
        {
            if (maxValue != null && minValue != null)
            {
                var diff = ((maxValue - minValue) / 5).Value;
                SetAxisLabelText(Y0, minValue.Value);
                SetAxisLabelText(Y1, minValue.Value + diff);
                SetAxisLabelText(Y2, minValue.Value + 2 * diff);
                SetAxisLabelText(Y3, minValue.Value + 3 * diff);
                SetAxisLabelText(Y4, minValue.Value + 4 * diff);
            }
            else Y0.Text = Y1.Text = Y2.Text = Y3.Text = Y4.Text = "-";
        }
        private Brush GetBrush(int index)
        {
            return brushes[index % brushes.Length];
        }

        private void SetAxisLabelText(TextBlock textBlock, double value)
        {
            textBlock.Text = AxisLabelDisplayConverter != null
                ? AxisLabelDisplayConverter.Convert(value, null, null, null) as string
                : string.Format(AxisLabelStringFormat, value);
        }
        private void AddBackgroundSerie(int maxCount)
        {
            var serie = new ChartSerie
            {
                Name = "__bck",
                Values = new List<DataPoint> { new DataPoint { Value = MinimalValue.Value }, new DataPoint { Value = MaximalValue.Value } }
            };
            var path = CreatePath(serie, maxCount);
            ChartArea.Children.Add(new Path
            {
                Data = Geometry.Parse(path),
                Stroke = Brushes.Transparent,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Visibility = Visibility.Visible
            });
        }
        private static IList<ChartSerie> Convert(IEnumerable source, string serieName, string serieValue, string pointName, string pointValue)
        {
            try
            {
                var result = new List<ChartSerie>();
                var serieType = source.GetType().GenericTypeArguments[0];
                foreach (var item in source)
                {
                    var serie = new ChartSerie
                    {
                        Name = serieType.GetProperty(serieName).GetValue(item) as string,
                        Values = new List<DataPoint>()
                    };
                    if (source.Cast<object>().Count() > 1 //more than single serie - name is required
                        && (string.IsNullOrEmpty(serie.Name) || result.Any(d => d.Name == serie.Name))) continue;
                    var points = serieType.GetProperty(serieValue).GetValue(item) as IEnumerable;
                    if (points == null) continue;
                    var pointType = points.GetType().GenericTypeArguments[0];
                    foreach (var p in points)
                    {
                        var dataPoint = new DataPoint
                        {
                            Name = pointType.GetProperty(pointName).GetValue(p) as string,
                            Value = System.Convert.ToDouble(pointType.GetProperty(pointValue).GetValue(p))
                        };
                        if (string.IsNullOrEmpty(dataPoint.Name)) continue;
                        serie.Values.Add(dataPoint);
                    }
                    result.Add(serie);
                }
                return result;
            }
            catch
            {
                return new List<ChartSerie>();
            }
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            base.OnRenderSizeChanged(sizeInfo);
            SetData(chartSeries);
        }
        #endregion
    }
}
