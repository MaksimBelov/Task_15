using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_15
{
    interface ISeries
    {
        void SetStart(int x);
        int GetNext();
        void Reset();
    }
    class ArithProgression : ISeries
    {
        private int x0;
        private int xi;

        public int D { get; set; } // шаг арифметической прогрессии

        public ArithProgression(int d)
        {
            D = d;
        }

        public void SetStart(int x)
        {
            x0 = x;
            xi = x;
        }

        public int GetNext()
        {
            xi += D;
            return xi;
        }

        public void Reset()
        {
            xi = x0;
        }

    }
    class GeomProgression : ISeries
    {
        private int x0;
        private int xi;

        public int Q { get; set; } // знаменатель геометрической прогрессии

        public GeomProgression(int q)
        {
            Q = q;
        }

        public void SetStart(int x)
        {
            x0 = x;
            xi = x;
        }

        public int GetNext()
        {
            xi *= Q;
            return xi;
        }

        public void Reset()
        {
            xi = x0;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            switch (Selection())
            {
                case 1:
                    {
                        Console.Write("Введите целочисленное значение первого члена арифметической прогрессии: ");
                        int x0 = EnterValue();

                        Console.Write("Введите целочисленное значение шага арифметической прогрессии: ");
                        int d = EnterValue();

                        Console.Write("Введите количество выводимых членов арифметической прогрессии: ");
                        int n = EnterValue();

                        ArithProgression arithProgression = new ArithProgression(d);

                        arithProgression.SetStart(x0);
                        Console.WriteLine("N1 = {0}", x0);

                        for (int i = 1; i < n; i++)
                        {
                            if ((long)x0 + (long)d * (long)i > Math.Pow(2, 31) - 1 || (long)x0 + (long)d * (long)i < -Math.Pow(2, 31))
                            {
                                Console.WriteLine("Ошибка! Переполнение переменной типа int");
                                break;
                            }
                            Console.WriteLine("N{0} = {1}", i + 1, arithProgression.GetNext());
                        }

                        arithProgression.Reset();
                        Console.WriteLine();
                        Console.WriteLine("Произведен сброс к начальному члену прогрессии N1 = {0}", x0);

                        Console.ReadKey();

                        break;
                    }

                case 2:
                    {
                        Console.Write("Введите целочисленное значение первого члена геометрической прогрессии: ");
                        int x0 = EnterValue();

                        Console.Write("Введите целочисленное значение знаменателя геометрической прогрессии: ");
                        int q = EnterValue();

                        Console.Write("Введите количество выводимых членов геометрической прогрессии: ");
                        int n = EnterValue();

                        GeomProgression geomProgression = new GeomProgression(q);

                        geomProgression.SetStart(x0);
                        Console.WriteLine("N1 = {0}", x0);

                        for (int i = 1; i < n; i++)
                        {
                            if (x0 * Math.Pow(q, i) > Math.Pow(2, 31) - 1 || x0 * Math.Pow(q, i) < -Math.Pow(2, 31))
                            {
                                Console.WriteLine("Ошибка! Переполнение переменной типа int");
                                break;
                            }
                            Console.WriteLine("N{0} = {1}", i + 1, geomProgression.GetNext());
                        }

                        geomProgression.Reset();
                        Console.WriteLine();
                        Console.WriteLine("Произведен сброс к начальному члену прогрессии N1 = {0}", x0);

                        Console.ReadKey();

                        break;
                    }
            }
        }

        static byte Selection()
        {
            bool error;
            byte selection = 1;

            Console.WriteLine("Выберите метод, который хотите использовать:");
            Console.WriteLine("1 - вычисление членов арифметической прогрессии");
            Console.WriteLine("2 - вычисление членов геометрической прогрессии");
            Console.WriteLine();

            do
            {
                try
                {
                    Console.Write("Ваш выбор: ");
                    byte select = Convert.ToByte(Console.ReadLine());
                    error = false;
                    selection = select;
                    if (select > 3 || select < 1)
                    {
                        Console.WriteLine("Ошибка! Введите номер требуемого метода 1 или 2");
                        error = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}", ex.Message);
                    error = true;
                }

            }
            while (error != false);

            Console.WriteLine();
            return selection;
        }

        static int EnterValue()
        {
            bool error;
            int value = 0;
            do
            {
                try
                {
                    int value1 = Convert.ToInt32(Console.ReadLine());
                    error = false;
                    value = value1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка! {0}", ex.Message);
                    Console.Write("Повторите ввод: ");
                    error = true;
                }
            }
            while (error != false);

            Console.WriteLine();
            return value;
        }
    }
}
