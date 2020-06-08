using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Xml.Linq;
using WpfApp2.laba20;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        FacultyContext db;
        public Window5()
        {
            InitializeComponent();
            db = new FacultyContext();
            db.Faculties.Load();// загружаем данные
            filmsGrid.ItemsSource = db.Faculties.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += fiveW_Closing;
        }
      
        private void fiveW_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        public string ToUpper(string name)
        {
            char[] arrayOfSymbols = name.ToCharArray();
            arrayOfSymbols[0] = char.ToUpper(name[0]);
            name = "";
            for (int i = 0; i < arrayOfSymbols.Length; i++)
                name += arrayOfSymbols[i];
            return name;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (university.Text == string.Empty)
            {
                MessageBox.Show("Имя не может быть пустым...");
                return;
            }
            if (facultyName.Text == string.Empty)
            {
                MessageBox.Show("Фамилия не может быть пустой...");
                return;
            }
            int a = 0;
            if (!int.TryParse(teachersCount.Text, out a))
            {
                MessageBox.Show("Количество должно быть числом...");
                return;
            }
            if (a <= 0)
            {
                MessageBox.Show("число должно быть > 0...");
                return;
            }
            MessageBox.Show(a.ToString() + "   " + ((uint)a).ToString());
            db.Faculties.Add(new Faculty(university.Text, facultyName.Text, (uint)a));
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (db.Faculties.Count() != 0)
            {
                db.Faculties.Remove(db.Faculties.First());
            }
            db.SaveChanges();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FacultyContext database = new FacultyContext();
            using (FacultyContext db = new FacultyContext())
            {
                var sortedFaculties = db.Faculties.OrderBy(f => f.University).ThenBy(f => f.FacultyName);
                foreach (var x in sortedFaculties)
                {
                    database.Faculties.Add(x);
                }
            }
            filmsGrid.ItemsSource = database.Faculties.Local.ToBindingList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FacultyContext database = new FacultyContext();
            using (FacultyContext db = new FacultyContext())
            {
                var groubByFaculty = db.Faculties.GroupBy(f => f.FacultyName);
                foreach (var x in groubByFaculty)
                {
                    foreach (var a in x)
                        database.Faculties.Add(a);
                }
                filmsGrid.ItemsSource = database.Faculties.Local.ToBindingList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FacultyContext database = new FacultyContext();
            using (FacultyContext db = new FacultyContext())
            {
                var groupByFaculty = db.Faculties.GroupBy(f => f.FacultyName);

                var uniqueFaculties = groupByFaculty.Where(g => g.Count() == 1);
                foreach (var x in uniqueFaculties)
                {
                    foreach (var a in x)
                        database.Faculties.Add(a);
                }
                filmsGrid.ItemsSource = database.Faculties.Local.ToBindingList();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (FacultyContext db = new FacultyContext())
            {
                MessageBox.Show($"{ db.Faculties.Sum(f => f.TeachersCount)} teachers");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            FacultyContext database = new FacultyContext();
            using (FacultyContext db = new FacultyContext())
            {
                var groupByUniversity = db.Faculties.GroupBy(f => f.University);

                foreach (var x in groupByUniversity)
                {
                    foreach (var a in x)
                        database.Faculties.Add(a);
                }
                filmsGrid.ItemsSource = database.Faculties.Local.ToBindingList();
            }
        }

        private void Button_Click_XML(object sender, RoutedEventArgs e)
        {
     
                XDocument xdoc = new XDocument();
                XElement films = new XElement("University");
                string mesBox = "";
                foreach (var x in db.Faculties)
                    films.Add(x);

                XElement filmes = new XElement("Unisers");

                filmes.Add(films);

                xdoc.Add(filmes);

               xdoc.Save("university.xml");

                XDocument xdo = XDocument.Load("university.xml");
               

            filmes = new XElement("Sort");
            xdoc = new XDocument();
            var sortFac = db.Faculties.OrderBy(f => f.University).ThenBy(f => f.FacultyName);
            foreach (var x in sortFac)
            {
                filmes.Add(x);
            }
            xdoc.Add(filmes);

            xdoc.Save("sort.xml");

            filmes = new XElement("GroupByName");
            xdoc = new XDocument();

            var grantStudent = db.Faculties.GroupBy(f => f.FacultyName);
            foreach (var x in grantStudent)
            {
                foreach (var a in x)
                    filmes.Add(a);
            }
         
            xdoc.Add(filmes);

            xdoc.Save("groupByName.xml");

            filmes = new XElement("GroupByUniver");
            xdoc = new XDocument();

            var grantStudentu = db.Faculties.GroupBy(f => f.University);
            foreach (var x in grantStudentu)
            {
                foreach (var a in x)
                    filmes.Add(a);
            }

            xdoc.Add(filmes);

            xdoc.Save("groupByUniver.xml");

            foreach (XElement el in xdo.Elements())
            {
               
                mesBox += el.ToString();
            }

            MessageBox.Show(mesBox);

        }
    }
}
