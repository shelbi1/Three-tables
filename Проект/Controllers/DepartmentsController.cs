using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sborka.Models;

namespace Sborka.Controllers
{
    class DepartmentsController
    {
        private Sborka_context _Context;
        public DepartmentsController(Sborka_context sborka_Context)
        {
            _Context = sborka_Context;
        }
        public void Create(Department dep)
        {
            _Context.Departments.Add(dep);
            _Context.SaveChanges();
        }
        public List<Department> List_Records()
        {
            return _Context.Departments.ToList();
        }
        public void Edit(int id, Department newDep)
        {
            Department d = _Context.Departments.FirstOrDefault(n => n.Id == id);
            if (d != null)
            {
                d = newDep;
                _Context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Department d = _Context.Departments.FirstOrDefault(n => n.Id == id);
            if (d != null)
            {
                _Context.Departments.Remove(d);
                _Context.SaveChanges();
            }
        }
    }
}
