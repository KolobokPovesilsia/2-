using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2_csharp
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //ввод данных пользователем
            Console.WriteLine("Введите рубли: ");
            uint rubles;
            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out rubles))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Введите целое число!");
                }
            }

            Console.WriteLine("Введите копейки: ");
            byte kopeks;
            while (true)
            {
                if (byte.TryParse(Console.ReadLine(), out kopeks))
                {
                    if (kopeks < 100)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите число до 100!");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Введите целое число!");
                }
            }
            
            Console.WriteLine("Введите рубли: ");
            uint rubles_1;
            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out rubles_1))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Введите целое число!");
                }
            }

            Console.WriteLine("Введите копейки: ");
            byte kopeks_1;
            while (true)
            {
                if (byte.TryParse(Console.ReadLine(), out kopeks_1))
                {
                    if (kopeks < 100)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Введите число до 100!");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Введите целое число!");
                }
            }

            ////////////////////////////////////////////////////
            //создание объекта Money
            Money money = new Money(rubles, kopeks);
            Console.WriteLine("Исходная сумма: " + money);

            //создание объекта Money
            Money moneyadd = new Money(rubles_1, kopeks_1);
            Console.WriteLine("Вычитаемая  сумма: " + moneyadd);

            Money result = money.Subtract(moneyadd);
            Console.WriteLine("Получившаяся сумма: " + result);

            Console.WriteLine("\nЗадание 3:");

            //тестирование унарных операций
            Console.WriteLine("\nТестирование унарных операций:");
            Console.WriteLine("После добавления копейки: " + ++money);
            Console.WriteLine("После вычитания копейки: " + --money);


            Console.WriteLine("\nТестирование операций приведения типов:");
            uint rubleAmount = (uint)money; // Явное приведение
            double kopeckAmount = money;     // Неявное приведение
            Console.WriteLine($"Количество рублей: {rubleAmount}");
            Console.WriteLine($"Количество копеек в рублях: {kopeckAmount}");

            //тестирование бинарных операций
            Console.WriteLine("\nТестирование бинарных операций:");
            Console.WriteLine("Сколько копеек вы хотите вычесть:");
            uint x;
            while (true)
            {
                if (uint.TryParse(Console.ReadLine(), out x))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод! Введите целое число!");
                }
            }
            Console.WriteLine($"Удаление {x} копеек: " + (money - x));

            //вычитание сумм
            Money result_1 = money - moneyadd;
            Console.WriteLine($"Вычитание из {money} {moneyadd}  даст" + (money - moneyadd));
        }
    }
}