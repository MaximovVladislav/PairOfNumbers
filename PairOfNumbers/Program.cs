using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000;

            int startValue = 1;
            int endValue = 10000;
            int doubleEndValue = endValue * 2;

            int[] numbers = new int[n];

            // заполняем массив псевдослучайными значениями 
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                numbers[i] = rand.Next(startValue, endValue + 1);
                //Console.Write("{0}, ", numbers[i]); // Долго выводит, надоело 
            }

            //numbers = new[] {8, 7, 4, 10, 6, 1, 7, 3}; 

            Console.WriteLine();

            Console.WriteLine("Введите число от {0} до {1}", startValue, doubleEndValue);
            string str = Console.ReadLine();

            int res;

            if (int.TryParse(str, out res))
            {
                if (res <= doubleEndValue && res > startValue)
                {
                    DateTime starTime = DateTime.Now;
                    var result = GetPairs(numbers, res);
                    TimeSpan span = DateTime.Now - starTime;

                    foreach (KeyValuePair<int, int> keyValuePair in result)
                    {
                        Console.WriteLine("{{{0}, {1}}}", keyValuePair.Value, keyValuePair.Key);
                    }

                    Console.WriteLine("Затрачено времени: {0}", span);
                }
                else
                {
                    Console.WriteLine("Число не входит в заданный диапазон");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели не число");
            }

            Console.ReadKey();
        }
        static Dictionary<int, int> GetPairs(int[] numbers, int sum)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();

            Array.Sort(numbers);

            int first = 0;
            int last = numbers.Length - 1;

            while (first < last)
            {
                int s = numbers[first] + numbers[last];

                if (sum == s)
                {
                    result.TryAdd(numbers[first], numbers[last]);
                    first++;
                    last--;
                }
                else
                {
                    if (s < sum) first++;
                    else last--;
                }
            }

            return result;
        }
    }
}
