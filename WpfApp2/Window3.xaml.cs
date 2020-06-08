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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();

        }


        public static List<List<string>> choices = new List<List<string>> { new List<string> { "Cоль", "Велосипед", "Cухари", "Мурманск" }, new List<string> { "Дома", "С парнем", "С друзьями", "С Slidan-ом" }, new List<string> { "Телекинез", "Автомат по КПиЯП", "Летать", "Есть и не толстеть" }, new List<string> { "Симпатия", "Все", "Cухари", "Я хочу салат((" }, new List<string> { "Снег", "Жара", "Прохлада", "Дождь" }, };
        public static List<string> textBox = new List<string>() { "Тест \"Какой ты салатик?\"", "Выбери что-то одно :", "Где будешь праздновать Новый год?", "Выбери суперспособность:", "Что такое любовь?", "Любимая погода?" };
        public static int temp = 0;
        public static int count = 0;

        public void ButtonManagment(int button)
        {
            if (button == 0)
            {
               
                start.Visibility = Visibility.Hidden;
                bg.Visibility = Visibility.Hidden;
                tBox.Text = textBox[temp];
                r1.Visibility = Visibility.Visible;
                r2.Visibility = Visibility.Visible;
                r3.Visibility = Visibility.Visible;
                r4.Visibility = Visibility.Visible;
                r1.Content = choices[0][0];
                r2.Content = choices[0][1];
                r3.Content = choices[0][2];
                r4.Content = choices[0][3];
              
            }
            if (temp == 5)
            {
                count += button;
                if (count >= 15)
                {
                    MessageBox.Show($"Вы салат Цезарь, Здорово");
                }
                else if (count >= 10)
                {
                    MessageBox.Show($"Вы Греческий салат, Неплохой вариант");
                }
                else if (count >= 10)
                {
                    MessageBox.Show($"Вы Оливье, Классека");
                }
                else if (count >= 5)
                {
                    MessageBox.Show($"Вы Вальдорфский салат, Оооу май");
                }
                else
                {
                    MessageBox.Show($"Вы Картофельный салат, Патриот");
                }

                temp = 0;
                count = 0;
                Window w = new MainWindow();
                w.Show();
                this.Close();
            }
            else
            {
               

                count += button;


                tBox.Text = textBox[temp + 1];
                r1.Content = choices[temp ][0];
                r2.Content = choices[temp ][1];
                r3.Content = choices[temp ][2];
                r4.Content = choices[temp ][3];
                ++temp;
            }

            }

        private void ButtonClickr1(object sender, RoutedEventArgs e)
        {
            ButtonManagment(1);
        }
        private void ButtonClickr2(object sender, RoutedEventArgs e)
        {
            ButtonManagment(2);
        }
        private void ButtonClickr3(object sender, RoutedEventArgs e)
        {
            ButtonManagment(3);
        }
        private void ButtonClickr4(object sender, RoutedEventArgs e)
        {
            ButtonManagment(4);
        }

        private void ButtonManagment(object sender, RoutedEventArgs e)
        {
            ButtonManagment(0);
        }
    }
        
   
}
