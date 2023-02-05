using System;
using System.Collections.Generic;
using System.Text;

namespace Sborka.Models
{
    class Employee
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Prophesy { get; set; }
        public int? DepartmentId { get; set; }
       
        public override string ToString()
        {
            return Id + " ФИО: " +FIO + " Специальность: " + Prophesy;
        }     
    }
}
