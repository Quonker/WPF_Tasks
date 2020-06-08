using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClick1(object sender, RoutedEventArgs e)
        {
            Window window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void ButtonClick2(object sender, RoutedEventArgs e)
        {
            Window window2 = new Window2();
            window2.Show();
            this.Close();
        }

        private void ButtonClick3(object sender, RoutedEventArgs e)
        {
            Window window3 = new Window3();
            window3.Show();
            this.Close();
        }

        private void ButtonClick4(object sender, RoutedEventArgs e)
        {
            Window window4 = new Window4();
            window4.Show();
            this.Close();
        }

        private void ButtonClick5(object sender, RoutedEventArgs e)
        {
            Window window5 = new Window5();
            window5.Show();
            this.Close();
        }

        private void ButtonClick6(object sender, RoutedEventArgs e)
        {
            Window window6 = new Window6();
            window6.Show();
            this.Close();
        }

    }
}
