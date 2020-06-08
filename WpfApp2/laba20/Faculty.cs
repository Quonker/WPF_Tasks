using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.laba20
{
    public class Faculty
    {
        [Key]
        public int ID { get; set; }
        public string University { get; set; }
        public string FacultyName { get; set; }
        public uint TeachersCount { get; set; }
        public List<string> speciality;
        public List<string> studentsSurnames;

      

        public Faculty(string u, string f, uint t)
        {
            University = u;
            FacultyName = f;
            TeachersCount = t;
            speciality = new List<string>();
            studentsSurnames = new List<string>();
        }

        public Faculty(string u, string f, uint t, List<string> sp, List<string> st)
        {
            University = u;
            FacultyName = f;
            TeachersCount = t;
            speciality = sp;
            for (int i = 0; i < st.Count; ++i)
            {
                st[i] = st[i].First().ToString().ToUpper() + String.Join("", st[i].Skip(1));
            }
            studentsSurnames = st;
        }
        public Faculty()
        {
            University = "шаражка";
            FacultyName = "поит";
            TeachersCount = 120;
            speciality = new List<string>() { "техник- программист" };
            studentsSurnames = new List<string>() { "Махнач", "Курлович", "Сосновский", "Костюкевич" };
        }
        public override string ToString()
        {
            return $"\nUniversity: {University}\nFaculty: {FacultyName}\nCount of teachers: {TeachersCount}\nSpecialyties: {speciality}\nStudents: {studentsSurnames}";
        }
        public static void SortingByNames(List<Faculty> faculties)
        {

            var AndrushaBlabes = faculties.OrderBy(x => x.FacultyName).ThenBy(x => x.University);
            foreach (var f in AndrushaBlabes)
            {
                Console.WriteLine(f);
            }
        }

        public static void GroupByFaculty(List<Faculty> faculties)
        {

            var qwerty = faculties.GroupBy(f => f.FacultyName);

            foreach (var s in qwerty)
            {

                Console.WriteLine(s.Key);
                foreach (var a in s)
                {
                    Console.WriteLine(a);
                }

            }
        }

        public static int SumOfTeacher(List<Faculty> faculties)
        {
            return faculties.Sum(f => f.FacultyName.Count());
        }

    }
}
