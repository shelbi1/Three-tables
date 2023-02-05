using Sborka.Controllers;
using Sborka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sborka.UIs
{
    class DepartmentsView
    {
        DepartmentsController departmentsController;
        public DepartmentsView(Sborka_context sborka_Context)
        {
            departmentsController = new DepartmentsController(sborka_Context);
        }
        public void StartUI()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберете номер действия из списка");
                Console.WriteLine("1. Отобразить список отделов \n2. Добавить отдел \n3. Редактировать отдел \n4. Удалить отдел \n5. Выйти в главное меню");
                string inp = Console.ReadLine();
                int choice = 0;
                bool ok = int.TryParse(inp, out choice);
                if (ok)
                {
                    switch (choice)
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
            foreach(var item in departmentsController.List_Records())
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void Create()
        {
            Console.WriteLine("Введите название отдела");
            string inp = Console.ReadLine();         
            if (!string.IsNullOrEmpty(inp))
            {
                Department d = new Department();
                d.Name = inp;
                departmentsController.Create(d);
            }

        }
        public void Edit()
        {
            Console.WriteLine("Введите номер отдела для редактирования");
            ListItems();
            string inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp))
            {
                int id_dep = 0;
                bool ok = int.TryParse(inp, out id_dep);
                if (ok)
                {
                    Department f_dep = departmentsController.List_Records().FirstOrDefault(n => n.Id == id_dep);
                    if (f_dep != null)
                    {
                        Console.WriteLine("Введите название отдела");
                        string new_name = Console.ReadLine();
                        if (!string.IsNullOrEmpty(new_name))
                        {
                            f_dep.Name = new_name;
                            departmentsController.Edit(id_dep,f_dep);
                        }
                        Console.WriteLine("Запись обновлена");
                    }

                }
               
            }

        }
        public void Delete()
        {
            Console.WriteLine("Введите номер отдела для удаления");
            ListItems();
            string inp = Console.ReadLine();
            if (!string.IsNullOrEmpty(inp))
            {
                int id_dep = 0;
                bool ok = int.TryParse(inp, out id_dep);
                if (ok)
                {
                    Department f_dep = departmentsController.List_Records().FirstOrDefault(n => n.Id == id_dep);
                    if (f_dep != null)
                    {                     
                       departmentsController.Delete(id_dep);                       
                       Console.WriteLine("Запись удалена");
                    }
                }

            }
        }
    }
}
