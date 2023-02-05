using Sborka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sborka.Controllers
{
    class ProductsController
    {
        private Sborka_context _Context;
        public ProductsController(Sborka_context context)
        {
            _Context = context;
        }

        public void Create(Product p)
        {
            _Context.Products.Add(p);
            _Context.SaveChanges();
        }
        public List<Product> List_Records()
        {
            return _Context.Products.ToList();
        }
        public void Edit(int id, Product newP)
        {
            Product p = _Context.Products.FirstOrDefault(n => n.Id == id);
            if (p != null)
            {
                p.Name = newP.Name;
                p.Price = newP.Price;
                p.EmployeeId = newP.EmployeeId;
                _Context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            Product p = _Context.Products.FirstOrDefault(n => n.Id == id);
            if (p != null)
            {
                _Context.Products.Remove(p);
                _Context.SaveChanges();
            }
        }
    }
}
