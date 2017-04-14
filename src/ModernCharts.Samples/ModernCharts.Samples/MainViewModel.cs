using ModernCharts.Samples.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModernCharts.Samples
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

            SimplePointSerie = new List<Serie>
            {
                new Serie
                {
                    Name = "Continents",
                    Points = new List<Point>
                    {
                        new Point { Name = "Africa", Value = 30370000 },
                        new Point { Name = "Antarctica", Value = 13720000 },
                        new Point { Name = "Asia", Value = 43820000 },
                        new Point { Name = "Europe", Value = 10180000 },
                        new Point { Name = "North America", Value = 24490000 },
                        new Point { Name = "Australia", Value = 9008500 },
                        new Point { Name = "South America", Value = 17840000 }
                    }
                }
            };

            WorldPopulation = new List<Serie>
            {
                new Serie
                {
                    Name = "World",
                    Points = new List<Point>
                    {
                        new Point { Name = "1500", Value =  585 },
                        new Point { Name = "1600", Value =  660 },
                        new Point { Name = "1700", Value =  710 },
                        new Point { Name = "1750", Value =  791 },
                        new Point { Name = "1800", Value =  978 },
                        new Point { Name = "1850", Value =  1262 },
                        new Point { Name = "1900", Value =  1650 },
                        new Point { Name = "1950", Value =  2521 },
                        new Point { Name = "1999", Value =  6008 },
                        new Point { Name = "2008", Value =  6707 },
                        new Point { Name = "2010", Value =  6896 },
                        new Point { Name = "2012", Value =  7052 },
                        new Point { Name = "2050", Value =  9725 },
                        new Point { Name = "2150", Value =  9746 }
                    }
                },
                new Serie
                {
                    Name = "Africa",
                    Points = new List<Point>
                    {
                        new Point { Name = "1500", Value =  86 },
                        new Point { Name = "1600", Value =  114 },
                        new Point { Name = "1700", Value =  106 },
                        new Point { Name = "1750", Value =  106 },
                        new Point { Name = "1800", Value =  107 },
                        new Point { Name = "1850", Value =  111 },
                        new Point { Name = "1900", Value =  133 },
                        new Point { Name = "1950", Value =  221 },
                        new Point { Name = "1999", Value =  783 },
                        new Point { Name = "2008", Value =  973 },
                        new Point { Name = "2010", Value =  1022 },
                        new Point { Name = "2012", Value =  1052 },
                        new Point { Name = "2050", Value =  2478 },
                        new Point { Name = "2150", Value = 2308 }
                    }
                },
                new Serie
                {
                    Name = "Asia",
                    Points = new List<Point>
                    {
                        new Point { Name = "1500", Value =  282 },
                        new Point { Name = "1600", Value =  350 },
                        new Point { Name = "1700", Value =  411 },
                        new Point { Name = "1750", Value =  502 },
                        new Point { Name = "1800", Value =  635 },
                        new Point { Name = "1850", Value =  809 },
                        new Point { Name = "1900", Value =  947 },
                        new Point { Name = "1950", Value =  1402 },
                        new Point { Name = "1999", Value =  3700 },
                        new Point { Name = "2008", Value =  4054 },
                        new Point { Name = "2010", Value =  4164 },
                        new Point { Name = "2012", Value =  4250 },
                        new Point { Name = "2050", Value =  5267 },
                        new Point { Name = "2150", Value = 5561 }
                    }
                },
                new Serie
                {
                    Name = "Europe",
                    Points = new List<Point>
                    {
                        new Point { Name = "1500", Value =  168 },
                        new Point { Name = "1600", Value =  170 },
                        new Point { Name = "1700", Value =  178 },
                        new Point { Name = "1750", Value =  190 },
                        new Point { Name = "1800", Value =  203 },
                        new Point { Name = "1850", Value =  276 },
                        new Point { Name = "1900", Value =  408 },
                        new Point { Name = "1950", Value =  547 },
                        new Point { Name = "1999", Value =  675 },
                        new Point { Name = "2008", Value =  732 },
                        new Point { Name = "2010", Value =  738 },
                        new Point { Name = "2012", Value =  740 },
                        new Point { Name = "2050", Value =  734 },
                        new Point { Name = "2150", Value = 517 }
                    }
                },
                new Serie
                {
                    Name = "Latin America",
                    Points = new List<Point>
                    {
                        new Point { Name = "1500", Value =  40 },
                        new Point { Name = "1600", Value =  20 },
                        new Point { Name = "1700", Value =  10 },
                        new Point { Name = "1750", Value =  16 },
                        new Point { Name = "1800", Value =  24 },
                        new Point { Name = "1850", Value =  38 },
                        new Point { Name = "1900", Value =  74 },
                        new Point { Name = "1950", Value =  167 },
                        new Point { Name = "1999", Value =  508 },
                        new Point { Name = "2008", Value =  577 },
                        new Point { Name = "2010", Value =  590 },
                        new Point { Name = "2012", Value =  603 },
                        new Point { Name = "2050", Value =  784 },
                        new Point { Name = "2150", Value = 912 },
                    }
                },
                new Serie
                {
                    Name = "North America",
                    Points = new List<Point>
                    {
                        new Point { Name = "1500", Value =  6 },
                        new Point { Name = "1600", Value =  3 },
                        new Point { Name = "1700", Value =  2 },
                        new Point { Name = "1750", Value =  2 },
                        new Point { Name = "1800", Value =  7 },
                        new Point { Name = "1850", Value =  26 },
                        new Point { Name = "1900", Value =  82 },
                        new Point { Name = "1950", Value =  172 },
                        new Point { Name = "1999", Value =  312 },
                        new Point { Name = "2008", Value =  337 },
                        new Point { Name = "2010", Value =  345 },
                        new Point { Name = "2012", Value =  351 },
                        new Point { Name = "2050", Value =  433 },
                        new Point { Name = "2150", Value = 398 }
                    }
                },
                new Serie
                {
                    Name = "Oceania",
                    Points = new List<Point>
                    {
                        new Point { Name = "1500", Value =  3 },
                        new Point { Name = "1600", Value =  3 },
                        new Point { Name = "1700", Value =  3 },
                        new Point { Name = "1750", Value =  2 },
                        new Point { Name = "1800", Value =  2 },
                        new Point { Name = "1850", Value =  2 },
                        new Point { Name = "1900", Value =  6 },
                        new Point { Name = "1950", Value = 13 },
                        new Point { Name = "1999", Value = 30 },
                        new Point { Name = "2008", Value = 34 },
                        new Point { Name = "2010", Value = 37 },
                        new Point { Name = "2012", Value = 38 },
                        new Point { Name = "2050", Value = 57 },
                        new Point { Name = "2150", Value = 51 }
                    }
                 }
            };

        }



        private IEnumerable simplePointSerie;
        private IEnumerable worldPopulation;




        public IEnumerable WorldPopulation
        {
            get { return worldPopulation; }
            set
            {
                if (value == worldPopulation) return;
                worldPopulation = value;
                RaisePropertyChanged();
            }
        }




        public IEnumerable SimplePointSerie
        {
            get { return simplePointSerie; }
            set
            {
                if (value == simplePointSerie) return;
                simplePointSerie = value;
                RaisePropertyChanged();
            }
        }






        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
