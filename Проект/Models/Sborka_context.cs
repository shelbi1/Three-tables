using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Sborka.Models
{
    class Sborka_context:DbContext
    {
        public Sborka_context():base("DefaultConnectiopn")
        {          
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
