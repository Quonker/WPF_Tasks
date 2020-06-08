using WpfApp2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    public class HalfWindowSize : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class PointFlexiblePosition : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            GraphDetails Param = (GraphDetails)parameter;
            double Size = (double)value;

            double Center = Size / 2;
            double Step = Size / Param.Range;

            return Center + (Param.Pos * Step);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception();
        }
    }

    public struct GraphDetails
    {
        public double Pos { get; set; }
        public double Range { get; set; }
    }

    class Point
    {
        public double X, Y;

        public Point(double X = 0, double Y = 0)
        {
            this.X = X;
            this.Y = Y;
        }
    }
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();

            double x1 = -100;
            double x2 = 100;
            double s = 1;
            Show(PointBuilder(x1, x2, s));
        }

        private List<Point> PointBuilder(double X, double XFinish, double Step)
        {
            List<Point> Points = new List<Point>();

            for (; X <= XFinish; X += Step)
            {
                // к Y  приравнивай свою функцию 

                double Y = ((X*X) - ( 2 * X) + 2) * (X - 1);
                Points.Add(new Point(X, Y));
            }
            return Points;
        }

        private void Show(List<Point> Points)
        {
            PointsLayer.Children.Clear();

            for (int i = 0; i < Points.Count - 1; i++)
            {
                double RangeX = Points.Max(x => Math.Abs(x.X)) * 2;
                double RangeY = Points.Max(x => Math.Abs(x.Y)) * 2;
                double MaxX = Points.Max(x => x.X);
                double MinX = Points.Min(x => x.X);
                double MaxY = Points.Max(x => x.Y);
                double MinY = Points.Min(x => x.Y);

                Point Curr = Points[i];
                Point Next = Points[i + 1];
                Line GraphLine = new Line() { Stroke = Brushes.Green, StrokeThickness = 2 };
                PointFlexiblePosition PFP = new PointFlexiblePosition();
                /*this.ActualHeight*/
                /*this.ActualWidth*/

                Binding Bind_X1 = new Binding("ActualWidth");
                Bind_X1.Source = this;
                Bind_X1.Converter = PFP;
                Bind_X1.ConverterParameter = new GraphDetails() { Pos = Curr.X, Range = RangeX };
                GraphLine.SetBinding(Line.X1Property, Bind_X1);

                Binding Bind_Y1 = new Binding("ActualHeight");
                Bind_Y1.Source = this;
                Bind_Y1.Converter = PFP;
                Bind_Y1.ConverterParameter = new GraphDetails { Pos = Curr.Y, Range = RangeY };
                GraphLine.SetBinding(Line.Y1Property, Bind_Y1);

                Binding Bind_X2 = new Binding("ActualWidth");
                Bind_X2.Source = this;
                Bind_X2.Converter = PFP;
                Bind_X2.ConverterParameter = new GraphDetails { Pos = Next.X, Range = RangeX };
                GraphLine.SetBinding(Line.X2Property, Bind_X2);

                Binding Bind_Y2 = new Binding("ActualHeight");
                Bind_Y2.Source = this;
                Bind_Y2.Converter = PFP;
                Bind_Y2.ConverterParameter = new GraphDetails { Pos = Next.Y, Range = RangeY };
                GraphLine.SetBinding(Line.Y2Property, Bind_Y2);

                PointsLayer.Children.Add(GraphLine);
            }
        }
    }
}