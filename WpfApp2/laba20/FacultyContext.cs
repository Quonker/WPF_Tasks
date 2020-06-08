using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.laba20
{
    public class FacultyContext  : DbContext
    {
        public FacultyContext() : base("StudentConnectionKPIPWithID")
    {

    }
    public DbSet<Faculty> Faculties { get; set; }
}
}
