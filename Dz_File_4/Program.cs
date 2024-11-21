using System;
namespace Dz_File_4
{
    class Program
    {
        static void PrintArray(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
        static double Sum(params double[] array)
        {
            double sum = 0;
            foreach (double d in array)
            {
                sum += d;
            }
            return sum;
        }
        static void Umnog(ref double itog, params double[] array)
        {
            foreach (double d in array)
            {
                itog *= d;
            }
        }
        static void Sred(out double itog, params double[] array)
        {
            itog = Sum(array) / array.Length;
        }
        public static void Show_number(int number)
        {
            string[] digits = new string[]
            {
            "###\n# #\n# #\n# #\n###",  // 0
            "  #\n  #\n  #\n  #\n  #",  // 1
            "###\n  #\n###\n#  \n###",  // 2
            "###\n  #\n###\n  #\n###",  // 3
            "# #\n# #\n###\n  #\n  #",  // 4
            "###\n#  \n###\n  #\n###",  // 5
            "###\n#  \n###\n# #\n###",  // 6
            "###\n  #\n  #\n  #\n  #",  // 7
            "###\n# #\n###\n# #\n###",  // 8
            "###\n# #\n###\n  #\n###"   // 9
            };

            if (number >= 0 && number <= 9)
            {
                Console.WriteLine(digits[number]);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ошибка: Число должно быть от 0 до 9!");
                Thread.Sleep(3000);
                Console.ResetColor();
            }
        }

        static void Zadanie_1()
        {
            Console.WriteLine(@"Задание 1. Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
            которые нужно поменять местами. Вывести на экран получившийся массив.");
            Random rand = new Random();
            int[] rand_numbers = new int[20];
            for (int i = 0; i < rand_numbers.Length; i++)
            {
                rand_numbers[i] = rand.Next(1, 1000);
            }
            PrintArray(rand_numbers);
            Console.WriteLine("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());
            int nomer1 = Array.IndexOf(rand_numbers, num1);
            int nomer2 = Array.IndexOf(rand_numbers, num2);
            if (nomer1 == -1 || nomer2 == -1)
            {
                Console.WriteLine("Одно или оба числа не найдены в массиве.");
            }
            else
            {
                int temp = rand_numbers[nomer1];
                (rand_numbers[nomer1], rand_numbers[nomer2]) = (rand_numbers[nomer2], rand_numbers[nomer1]);
                PrintArray(rand_numbers);
            }
        }
        static void Zadanie_2()
        {
            Console.WriteLine(@"Задаине 2. Написать метод, где в качества аргумента будет передан массив (ключевое слово
            params). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение
            массива. Вывести (out) среднее арифметическое в массиве.");
            Console.WriteLine("допускается набор чисел через пробел");
            double[] array = Console.ReadLine().Split(' ').Select(i => double.Parse(i)).ToArray<double>();
            Console.WriteLine($"Сумма массива: {Sum((array))}");
            double vrem = 1;
            Umnog(ref vrem, (array));
            Console.WriteLine($"Произведение массива: {vrem}");
            double temp = -1;
            Sred(out temp, (array));
            Console.WriteLine($"Среднее арифметическое массива: {temp}");
        }
        static void Zadanie_3()
        {
            Console.WriteLine(@"Задание 3. Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
            изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
            должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
            пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
            завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта
            должны сработать) - консоль закроется.");
            while (true)
            {
                try
                {
                    Console.Write("Введите цифру ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "exit" || input.ToLower() == "закрыть")
                    {
                        Console.WriteLine("Программа завершена.");
                        break;
                    }
                    if (int.TryParse(input, out int number))
                    {
                        if (number >= 0 && number <= 9)
                        {
                            Show_number(number);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка: Число должно быть от 0 до 9!");
                            Thread.Sleep(3000);
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        throw new FormatException("Вводите цифоры, а не буковы");
                    }
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Thread.Sleep(3000);
                    Console.ResetColor();
                }

            }
        }
        static void Zadanie_4()
        {
            Console.WriteLine(@"Задание 4. Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив
            фраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
            бабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз для
            ворчания. Напишите метод (внутри структуры), который на вход принимает деда,
            список матерных слов (params). Если дед содержит в своей лексике матерные слова из
            списка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.");
            // Массив матерных слов
            string[] badWords = { "бляха", "дерьмо", "гнида", "сука" };

            // Создание 5 дедов с разным количеством фраз
            Ded[] grandfathers = new Ded[]
            {
            new Ded("Дед 1", Worchelnost.Низкий, new string[] { "Проклятие!" }),
            new Ded("Дед 2", Worchelnost.Средний, new string[] { "Наркоманы", "бляха" }),
            new Ded("Дед 3", Worchelnost.Высокий, new string[] { "сука", "гнида" }),
            new Ded("Дед 4", Worchelnost.Низкий, new string[] { "Что за чертовщина!" }),
            new Ded("Дед 5", Worchelnost.Средний, new string[] { "Проклятие!", "Черт!", "дерьмо" })
            };

            // Проверка каждого деда на матерные слова и вывод фингалов
            foreach (var grandfather in grandfathers)
            {
                int bruises = grandfather.CheckForBadWords(badWords);
                Console.WriteLine($"{grandfather.Name} получил {bruises} фингалов от бабки.");
            }

        }
        static void Main()
        {
            Zadanie_1();
            Zadanie_2();
            Zadanie_3();
            Zadanie_4();
        }
        public enum Worchelnost
        {
            Низкий = 1,
            Средний = 2,
            Высокий = 3
        }
        public struct Ded
        {
            public string Name;
            public Worchelnost Level;
            public string[] Phrases;
            public int Bruises;

            public Ded(string name, Worchelnost level, string[] phrases)
            {
                Name = name;
                Level = level;
                Phrases = phrases;
                Bruises = 0;
            }

            public int CheckForBadWords(string[] badWords)
            {
                int bruisesAdded = 0;

                foreach (var phrase in Phrases)
                {
                    foreach (var badWord in badWords)
                    {
                        if (phrase.Contains(badWord))
                        {
                            bruisesAdded++;
                        }
                    }
                }

                Bruises += bruisesAdded;
                return bruisesAdded;
            }
        }
    }
}
