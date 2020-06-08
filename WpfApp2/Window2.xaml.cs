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
    class Creater
    {
        private int id;
        private string label;
        private bool isChecked;

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }
        public bool IsChecked { get => isChecked; set => isChecked = value; }

        public Creater(int id, string label, bool isChecked)
        {
            Id = id;
            Label = label;
            IsChecked = isChecked;
        }

        public override string ToString()
        {
            return $"{Label} -> {IsChecked}";
        }
    }
    class Request
    {
        private int startPriceRange;
        private int finishPriceRange;
        private List<Creater> creaters = new List<Creater>()
        {
            new Creater(0,"Sony",false),
            new Creater(1,"Sega",false),
            new Creater(2,"Microsoft",false),
            new Creater(3,"Nintendo",false),
        };
        public int StartPriceRange
        {
            get => startPriceRange;
            set
            {
                if (value < 0)
                    value = Math.Abs(value);
                startPriceRange = value;
            }
        }
        public int FinishPriceRange
        {
            get => finishPriceRange;
            set
            {
                if (value < 0)
                    value = Math.Abs(value);
                if (value < StartPriceRange)
                {
                    int temp = value;
                    value = StartPriceRange;
                    StartPriceRange = temp;
                }
                finishPriceRange = value;
            }
        }
        public List<Creater> Creaters { get => creaters; set => creaters = value; }

        public Request(int start, int finish, List<bool> values)
        {
            StartPriceRange = start;
            FinishPriceRange = finish;
            for (int i = 0; i != creaters.Count; ++i)
                creaters[i].IsChecked = values[i];
            Creaters = creaters;
        }

        public string PrintCreators()
        {
            string creaters = "";
            foreach (Creater creater in Creaters)
                creaters += creater + "\n";
            return creaters;
        }

        public override string ToString()
        {
            return $"start: {StartPriceRange} \n finish: {FinishPriceRange} \n {PrintCreators()}";
        }
    }
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        private void acceptButton_Click(object sender, RoutedEventArgs e)
        {
            if (inputFinish.Text != "" && inputStart.Text != "")
            {
                bool[] values = new bool[] {sony.IsChecked.Value,sega.IsChecked.Value,microsoft.IsChecked.Value, nintendo.IsChecked.Value};
                Request request = new Request(Convert.ToInt32(inputStart.Text), Convert.ToInt32(inputFinish.Text), values.ToList());
                MessageBox.Show(request.ToString());
            }
            else
            {
                MessageBox.Show("Please, fill inputs");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
