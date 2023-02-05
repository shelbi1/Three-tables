using Sborka.Models;
using Sborka.UIs;
using System;

namespace Sborka
{
    class Program
    {
        static void Main(string[] args)
        {
            Sborka_context context = new Sborka_context();
            MainView mainView = new MainView(context);
            mainView.Start();
        }
    }
}
