using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Factotial
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Введите число, от которого будем брать факториал:");
            int startNumber = Convert.ToInt32(Console.ReadLine());


            Task checkTask = new Task(() =>
            {
               int pluralityCheck = 1;
               for (int j = 1; j <= startNumber; j++)
               {
                   pluralityCheck *= j;
                   Console.WriteLine("Проверка работы асинхронного метода в классе Programm - {0}", pluralityCheck);
                   Thread.Sleep(200);
               }
            });
            checkTask.Start();
            

            await Task.WhenAll(FactorialAsync(startNumber),checkTask);
            Console.WriteLine("Метод Main окончил работу.");
            Console.ReadKey();

        }
        static async Task<int> FactorialAsync(int n)
        {
            int result = await Task.Run(() =>
            {
                int plurality = 1;
                for (int i = 1; i <= n; i++)
                {
                    plurality *= i;
                    Console.WriteLine("Асинхронный метод сейчас выдаёт значение - {0}", plurality);
                    Thread.Sleep(300);
                }                
                return plurality;
            });
            return result;
        }
    }
}
