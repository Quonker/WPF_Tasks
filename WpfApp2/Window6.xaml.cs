using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; ; // Default file name
            dlg.DefaultExt = ".txt"; ; // Default file extension
            dlg.Filter = "Text documents(.txt)| *.txt"; ; // Filter files by extension
                                                          // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                File.WriteAllText(filename, (text5.Text + "\n" + text6.Text + "\n" + text7.Text + "\n" + text8.Text + "\n"));
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog dlg = new System.Windows.Controls.PrintDialog();
            dlg.PageRangeSelection = PageRangeSelection.AllPages;
            dlg.UserPageRangeEnabled = true;
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            if (result == true)
            {
                // Print document
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            string str = text1.Text + " " + text2.Text + " " + text3.Text + " " + text4.Text + " " + text5.Text + " "
                + text6.Text + " " + text7.Text + " " + text8.Text + " " + text8.Text + " " + text10.Text + " "
                + text11.Text + " " + text12.Text + " " + text13.Text + " " + text14.Text + " " + text15.Text + " " + text16.Text + " "
                + text17.Text + " " + text18.Text + " " + text19.Text + " " + text20.Text + " " + text22.Text + " "
                + text23.Text + " " + text24.Text;
            int count = str.Split().ToList().FindAll(x => x.Contains(input.Text)).Count;
            if (count > 0)
                MessageBox.Show("Встречается " + count + " раз(а)");
            else
                MessageBox.Show("Не встречается");
        }
    }
}
