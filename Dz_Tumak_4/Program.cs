using System;
namespace Dz_Tumak_4
{
    class Program
    {
        static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        static void Swap(ref string a, ref string b)
        {
            (a, b) = (b, a);
        }
        public static bool Popitka_Factorial(int a, out long res)
        {
            res = 1;

            try
            {
                checked
                {
                    for (int i = 1; i <= a; i++)
                    {
                        res *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                res = 0;
                return false;
            }
        }
        public static long Rekurs_Factorial(int a)
        {
            if (a <= 1)
            {
                return 1;
            }
            return a * Rekurs_Factorial(a - 1);
        }
        static int NOD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a = a % b;
                }
                else
                {
                    b = b % a;
                }
            }
            return (a + b);
        }
        static int NOD(int a, int b, int c)
        {
            return (NOD(NOD(a, b), c));
        }
        static int Fibonacci_number(int n)
        {
            if (n <= 1) return 0;
            if (n == 2) return 1;
            else return (Fibonacci_number(n - 1) + Fibonacci_number(n - 2));
        }
        static void Upr_5_1()
        {
            Console.WriteLine(@"Упражнение 5.1. Написать метод, возвращающий наибольшее из двух чисел. Входные
            параметры метода – два целых числа. Протестировать метод.");
            Console.WriteLine("Введите первое число:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            int b = int.Parse(Console.ReadLine());

            int maxNumber = Max(a, b);
            Console.WriteLine($"Наибольшее число: {maxNumber}");
        }

        static void Upr_5_2()
        {
            Console.WriteLine(@"Упражнение 5.2. Написать метод, который меняет местами значения двух передаваемых
            параметров. Параметры передавать по ссылке.");
            Console.WriteLine("Введите первый параметр:");
            string a = Console.ReadLine();
            Console.WriteLine("Введите второй параметр:");
            string b = Console.ReadLine();
            Swap(ref a, ref b);
            Console.WriteLine($"{a} {b}");
        }
        static void Upr_5_3()
        {
            Console.WriteLine(@"Упражнение 5.3 Написать метод вычисления факториала числа, результат вычислений
            передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
            если в процессе вычисления возникло переполнение, то вернуть значение false. Для
            отслеживания переполнения значения использовать блок checked.");
            Console.WriteLine("Введите число");
            int a = int.Parse(Console.ReadLine());
            bool done = Popitka_Factorial(a, out long factorial);

            if (done)
            {
                Console.WriteLine($"Факториал равен {factorial}");
            }
            else
            {
                Console.WriteLine($"Ошибка возникло переполнение");
            }

        }
        static void Upr_5_4()
        {
            Console.WriteLine(@"Упражнение 5.4 Написать рекурсивный метод вычисления факториала числа.");
            Console.WriteLine("Введите число");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine($"Факториал равен {Rekurs_Factorial(a)}");
        }
        static void Dz_5_1()
        {
            Console.WriteLine(@"Домашнее задание 5.1 Написать метод, который вычисляет НОД двух натуральных чисел
            (алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех
            натуральных чисел.");
            Console.WriteLine("Введите 1 число");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите 2 число");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine($"НОД этих двух чисел равно {NOD(a, b)}");
            Console.WriteLine("Введите 3 число");
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine($"НОД этих трёх чисел равно {NOD(a, b, c)}");
        }
        static void Dz_5_2()
        {
            Console.WriteLine(@"Домашнее задание 5.2 Написать рекурсивный метод, вычисляющий значение n-го числа
            ряда Фибоначчи. Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
            13... Для таких чисел верно соотношение Fk = Fk-1 + Fk-2 .");
            Console.WriteLine("Введите номер числа Фибоначчи");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Значение {n}-го числа Фибоначчи равно: {Fibonacci_number(n)}");
        }
        static void Main()
        {
            Upr_5_1();
            Upr_5_2();
            Upr_5_3();
            Upr_5_4();
            Dz_5_1();
            Dz_5_2();

        }
    }
}