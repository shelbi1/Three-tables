using System;
using System.Collections.Generic;
using System.Text;

namespace Sborka.Models
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Id + " Название отдела : " + Name;            
        }
    }
}
