using System;
using System.Collections.Generic;
using System.Linq;

namespace YieldReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var num in GetNumbers())
            {
                Console.WriteLine(num);
            }

            var result = GetNumbers();
            IEnumerator<int> enumerator = result.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                Console.WriteLine(item);
            }

            foreach (var num in GetNumOrdinary().Take(2))
            {
                Console.WriteLine(num);
            }

            foreach (var num in GetNumYield().Take(2))
            {
                Console.WriteLine(num);
            }


            var list = new List<int> { 1, 2, 3, 4, 5, 6 };

            foreach (var num in Totals(list))
            {
                Console.WriteLine(num);
            }


        }

        private static IEnumerable<int> Totals(List<int> list)
        {
            var total = 0;
            foreach (var num in list)
            {
                total += num;
                yield return total;
            }
        }

        private static IEnumerable<int> GetNumYield()
        {
            var i = 0;
            while (true)
            {
                yield return ++i;
            }
        }

        private static IEnumerable<int> GetNumOrdinary()
        {
            var i = 0;
            var result = new List<int>();

            while (i > 1000)
            {
                result.Add(++i);
            }

            return result;

        }

        private static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}
