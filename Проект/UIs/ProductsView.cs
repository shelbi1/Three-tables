using Sborka.Controllers;
using Sborka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sborka.UIs
{
    class ProductsView
    {
        ProductsController prodController;
        Sborka_context _context;
        public ProductsView(Sborka_context sborka_Context)
        {
            prodController = new ProductsController(sborka_Context);
            _context = sborka_Context;

        }
        public void StartUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберете номер действия из списка");
                Console.WriteLine("1. Отобразить список продуктов \n2. Добавить продукт \n3. Редактировать продукт \n4. Удалить продукт \n5. Выйти в главное меню");
                string inp = Console.ReadLine();
                int choise = 0;
                bool ok = int.TryParse(inp, out choise);
                if (ok)
                {
                    switch (choise)
                    {
                        case 1:
                            ListItems();
                            Console.ReadLine();
                            break;
                        case 2:
                            Create();
                            Console.ReadLine();
                            break;
                        case 3:
                            Edit();
                            Console.ReadLine();
                            break;
                        case 4:
                            Delete();
                            Console.ReadLine();
                            break;
                        case 5:
                            return;
                    }
                }
            }

        }
        public void ListItems()
        {
            List<Employee> employees = _context.Employees.ToList();
            List<Department> departments = _context.Departments.ToList();

            foreach (var item in prodController.List_Records())
            {
                string empName = "";
                string depName = "";
                var empl = employees.FirstOrDefault(n => n.Id == item.EmployeeId);
                if (empl != null)
                {
                    empName = empl.FIO;
                    var depl = departments.FirstOrDefault(n => n.Id == empl.DepartmentId);
                    if (depl != null)
                    {
                        depName = depl.Name;
                    }
                }
                Console.WriteLine(item.ToString() + " Сотрудник : " + empName+" Отдел " +depName);
            }
        }
        public void ListItemsEmp()
        {
            foreach (var item in _context.Employees.ToList())
            {
                Console.WriteLine(item.ToString());
            }
            
        }

        public void Create()
        {
            Console.WriteLine("Введите название продукта");
            string name = Console.ReadLine();
            Console.WriteLine("Введите стоимость");
            string str_price = Console.ReadLine();
            double price = 0;
            bool pr_ok = double.TryParse(str_price,out price);
            Console.WriteLine("Выберете номер сотрудника для добавления продукта");
            ListItemsEmp();
            string str_empl = Console.ReadLine();
            if (!string.IsNullOrEmpty(str_empl))
            {
                int id_empl = 0;
                bool ok = int.TryParse(str_empl, out id_empl);
                if (ok && !string.IsNullOrEmpty(name) && price>0)
                {
                    Product product = new Product { Name = name, Price = price, EmployeeId = id_empl };
                    prodController.Create(product);
                    Console.WriteLine("Запись добавлена");
                }
            }
        }
        public void Edit()
        {
            Console.WriteLine("Введите номер продукта для редактирования");
            ListItems();
            string inp_prod = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp_prod))
            {
                int id_prod = 0;
                bool ok = int.TryParse(inp_prod, out id_prod);
                if (ok)
                {
                    Product f_prod = prodController.List_Records().FirstOrDefault(n => n.Id == id_prod);
                    if (f_prod != null)
                    {

                        Console.WriteLine("Введите название продукта");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите стоимость");
                        string str_price = Console.ReadLine();
                        double price = 0;
                        bool pr_ok = double.TryParse(str_price, out price);
                        Console.WriteLine("Выберете номер сотрудника для добавления продукта");
                        ListItemsEmp();
                        string str_empl = Console.ReadLine();
                        if (!string.IsNullOrEmpty(str_empl))
                        {
                            int id_empl = 0;
                            bool ok_empl = int.TryParse(str_empl, out id_empl);
                            if (ok_empl && !string.IsNullOrEmpty(name) && price > 0)
                            {
                                Product product = new Product { Name = name, Price = price, EmployeeId = id_empl };
                                prodController.Edit(id_prod,product);
                                Console.WriteLine("Запись обновлена");
                            }
                        }
                    }

                }

            }
        }
        public void Delete()
        {
            Console.WriteLine("Введите номер продукта для удаления");
            ListItems();
            string inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp))
            {
                int id_dep = 0;
                bool ok = int.TryParse(inp, out id_dep);
                if (ok)
                {
                    Product f_prod = prodController.List_Records().FirstOrDefault(n => n.Id == id_dep);
                    if (f_prod != null)
                    {
                        prodController.Delete(id_dep);
                        Console.WriteLine("Запись удалена");
                    }
                }

            }
        }
    }
}
