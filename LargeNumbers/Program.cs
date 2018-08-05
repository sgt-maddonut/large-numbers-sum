using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string x, y, z;
                Console.Write("Первое число: ");
                x = Console.ReadLine();
                Console.Write("Второе число: ");
                y = Console.ReadLine();
                z = SumNumbers(x, y);
                Console.WriteLine("Сумма: " + z);
                Console.WriteLine();
            }
        }

        static string SumNumbers(string x, string y)
        {
            string result = "";
            // Длина первого числа
            int xMaxIndex = x.Length - 1;
            // Длина второго числа
            int yMaxIndex = y.Length - 1;
            // Количество цифр в самом длинном числе
            int maxLength = x.Length > y.Length ? x.Length : y.Length;
            // Перенос
            int carryOver = 0;

            for (int i = 0; i < maxLength; i++)
            {
                var xIndex = xMaxIndex - i;
                var yIndex = yMaxIndex - i;
                var xUnit = xIndex >= 0 ? getDigit(x, i) : 0;
                var yUnit = yIndex >= 0 ? getDigit(y, i) : 0;
                var naturalSum = carryOver + xUnit + yUnit;

                if (i < maxLength - 1)
                {
                    result = (naturalSum % 10).ToString() + result;
                    // Проверка на перенос в другой разряд
                    carryOver = (naturalSum / 10) > 0 ? 1 : 0;
                }
                else
                {
                    result = naturalSum.ToString() + result;
                }
            }

            return result;
        }

        // Получение цифры из текущего разряда
        private static int getDigit(string x, int y)
        {
            return Convert.ToInt32(x[x.Length - 1 - y].ToString());
        }
    }
}
