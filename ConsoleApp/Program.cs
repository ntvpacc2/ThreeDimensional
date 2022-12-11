using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Тестирование вычисления объёма для шара:");
                    Console.WriteLine("Введите радиус:");
                    double.TryParse(Console.ReadLine(), out double r);
                    Console.WriteLine(new Ball(r).ToString());

                    Console.WriteLine("Тестирование вычисления объёма для пирамиды:");
                    Console.WriteLine("Введите высоту:");
                    double.TryParse(Console.ReadLine(), out double h);
                    Console.WriteLine("Введите площадь основания:");
                    double.TryParse(Console.ReadLine(), out double s);
                    Console.WriteLine(new Pyramid(s, h));

                    Console.WriteLine("Тестирование вычисления объёма для параллелепипеда:");
                    Console.WriteLine("Введите ребро:");
                    double.TryParse(Console.ReadLine(), out double a);
                    Console.WriteLine(new Parallelepiped(r).ToString());

                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
