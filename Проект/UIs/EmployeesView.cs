using Sborka.Controllers;
using Sborka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sborka.UIs
{
    class EmployeesView
    {
        EmployeeController emplController;
        Sborka_context _context;
        public EmployeesView(Sborka_context sborka_Context)
        {
            emplController = new EmployeeController(sborka_Context);
            _context = sborka_Context;

        }
        public void StartUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберете номер действия из списка");
                Console.WriteLine("1. Отобразить список сотрудников \n2. Добавить сотрудника \n3. Редактировать сотрудника \n4. Удалить сотрудника \n5. Выйти в главное меню");
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
            List<Department> departments = _context.Departments.ToList();

            foreach (var item in emplController.List_Records())
            {
                string depName = "";
                Department depl = departments.FirstOrDefault(n => n.Id == item.DepartmentId);
                if (depl != null)
                {
                    depName = depl.Name;
                   
                }
                Console.WriteLine(item.ToString() + " Отдел : " + depName);
            }
        }
        public void ListItemsDep()
        {
            foreach (var item in _context.Departments.ToList())
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void Create()
        {
            Console.WriteLine("Введите ФИО сотрудика");
            string name = Console.ReadLine();
            Console.WriteLine("Введите специальность сотрудика");
            string proph = Console.ReadLine();
            Console.WriteLine("Выберете номер отдела для сотрудника");
            ListItemsDep();
            string inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp))
            {
                int id_dep = 0;
                bool ok = int.TryParse(inp, out id_dep);
                if (ok&&!string.IsNullOrEmpty(name)&&!string.IsNullOrEmpty(proph))
                {
                    Employee employee = new Employee { FIO = name, Prophesy = proph, DepartmentId = id_dep };
                    emplController.Create(employee);
                    Console.WriteLine("Запись добавлена");
                }

            }

        }
        public void Edit()
        {
            Console.WriteLine("Введите номер сотрудника для редактирования");
            ListItems();
            string inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp))
            {
                int id_empl = 0;
                bool ok = int.TryParse(inp, out id_empl);
                if (ok)
                {
                    Employee f_empl = emplController.List_Records().FirstOrDefault(n => n.Id == id_empl);
                    if (f_empl != null)
                    {
                        Console.WriteLine("Введите ФИО сотрудика");
                        string name = Console.ReadLine();
                        Console.WriteLine("Введите специальность сотрудика");
                        string proph = Console.ReadLine();
                        Console.WriteLine("Выберете номер отдела для сотрудника");
                        ListItemsDep();
                        string inp_depstr = Console.ReadLine();
                        int inp_dep = 0;
                        if (!string.IsNullOrEmpty(inp_depstr))
                        {
                            int id_dep = 0;
                            bool oks = int.TryParse(inp_depstr, out inp_dep);
                            if (oks && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(proph))
                            {
                                Employee employee = new Employee { FIO = name, Prophesy = proph, DepartmentId = inp_dep };
                                emplController.Edit(id_empl, employee);
                                Console.WriteLine("Запись обновлена");

                            }

                        }
                    }

                }

            }
        }
        public void Delete()
        {
            Console.WriteLine("Введите номер сотрудника для удаления");
            ListItems();
            string inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp))
            {
                int id_dep = 0;
                bool ok = int.TryParse(inp, out id_dep);
                if (ok)
                {
                    Employee f_dep = emplController.List_Records().FirstOrDefault(n => n.Id == id_dep);
                    if (f_dep != null)
                    {
                        emplController.Delete(id_dep);
                        Console.WriteLine("Запись удалена");
                    }
                }

            }
        }
    }
}
