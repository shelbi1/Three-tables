using Sborka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sborka.Controllers
{
    class EmployeeController
    {
        private Sborka_context _Context;
        public EmployeeController(Sborka_context context)
        {
            _Context = context;
        }

        public void Create(Employee emp)
        {
            _Context.Employees.Add(emp);
            _Context.SaveChanges();
        }
        public List<Employee> List_Records()
        {
            return _Context.Employees.ToList();
        }
        public void Edit(int id, Employee newEmp)
        {
            Employee d = _Context.Employees.FirstOrDefault(n => n.Id == id);
            if (d != null)
            {
                d.DepartmentId = newEmp.DepartmentId;
                d.FIO = newEmp.FIO;
                d.Prophesy = newEmp.Prophesy;
                _Context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Employee d = _Context.Employees.FirstOrDefault(n => n.Id == id);
            if (d != null)
            {
                _Context.Employees.Remove(d);
                _Context.SaveChanges();
            }
        }
    }
}
