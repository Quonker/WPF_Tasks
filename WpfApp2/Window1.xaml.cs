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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string text = textBox1.Text;
            
            int count = int.Parse(textBox2.Text);
            string substring = textBox3.Text;

            StringBuilder result = new StringBuilder();

            if (count > 0)
            {
                for (int i = 0; i < text.Length; ++i)
                {
                    result.Append(text[i]);
                    if(i % count == 0 && i != 0)
                    {
                        result.Append(substring);
                    }

                }
            }
            string resultStr = result.ToString();
            if (resultStr != "")
            {
                MessageBox.Show(resultStr);
            }

        }
    }
}
