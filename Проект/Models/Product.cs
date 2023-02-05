using System;
using System.Collections.Generic;
using System.Text;

namespace Sborka.Models
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int? EmployeeId { get; set; }

        public override string ToString()
        {
            return Id + " Название: " + Name + " Стоимость: " + Price;
        }
    }
}
