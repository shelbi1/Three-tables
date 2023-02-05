using Sborka.Controllers;
using Sborka.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sborka.UIs
{
    class MainView
    {
        DepartmentsView departmentsView;
        EmployeesView employeesView;
        ProductsView productsView;
        public MainView(Sborka_context sborka_Context)
        {
             departmentsView = new DepartmentsView(sborka_Context);
            employeesView = new EmployeesView(sborka_Context);
            productsView = new ProductsView(sborka_Context);
        }
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("В данном приложении используются три таблицы \n" +
                    "Отделы Сотрудники Продукция \n Сотрудники хранят информацию об отделах\n" +
                    "а также изготавливат продукцию");
                Console.WriteLine("Выберете номер объекта из списка");
                Console.WriteLine("1. Отделы \n2. Сотрудники \n3. Продукция \n4. Выход");
                string inp = Console.ReadLine();
                int choise = 0;
                bool ok = int.TryParse(inp, out choise);
                if (ok)
                {
                    switch (choise)
                    {
                        case 1:
                        departmentsView.StartUI();
                            break;
                        case 2:
                            employeesView.StartUI();
                            break;
                        case 3:
                            productsView.StartUI();
                            break;
                        case 4:
                            return;
                    }
                }
            }
           
            


        }
    }
}
