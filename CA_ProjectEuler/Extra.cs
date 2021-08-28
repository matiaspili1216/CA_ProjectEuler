using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CA_ProjectEuler
{
    public static class Extra
    {
        public static string RemoveChars(this string value, params char[] items) => new string(value.Where(c => !items.Contains(c)).ToArray());

        public static long GetFibonacciValue_ByStep(int step)
        {
            if (step <= 1) { return 1; }
            else
            {
                var Sqrt5 = Math.Sqrt(5.0);
                return (long)((Math.Pow(1 + (Sqrt5 / 2), step) - Math.Pow(1 - (Sqrt5 / 2), step)) / Sqrt5);
            }
        }

        public static List<long> GetFactors(this long number, bool isIncluded = true)
        {
            List<long> fact = new List<long>();

            long Max = isIncluded ? number : number - 1;

            for (long i = 1; i <= Max; i++)
            {
                if (number % i == 0)
                {
                    fact.Add(i);
                }
            }

            return fact;
        }

        public static List<long> GetPrimesFactors(this long number)
        {
            List<long> fact = new List<long>();

            for (long i = 3; i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    if (i.IsPrime())
                    {
                        fact.Add(i);
                    }
                }
            }

            return fact;
        }

        public static List<long> GetPrimes(int max, bool whitNegatives = false) => GetPrimes((long) max, whitNegatives);

        public static List<long> GetPrimes(long max, bool whitNegatives = false)
        {
            /*http://es.wikipedia.org/wiki/Criba_de_Erat%C3%B3stenes */

            List<long> result = new List<long> { 2 };

            for (int i = 3; i <= max; i += 2)
            {
                result.Add(i);
            }

            for (int i = 1; ; i++)
            {
                var newPrime = result.ElementAt(i);
                result = result.Where(p => p == newPrime || p % newPrime != 0).ToList();

                if (Math.Pow(newPrime, 2) > max) { break; }
            }

            if (whitNegatives)
            {   
                result.AddRange(result.Select(x => -x));
            }

            return result;
        }

        public static bool IsPrime(this BigInteger integer)
        {
            if (integer == 1) { return false; }
            else if (integer == 2) { return true; }
            else if (integer % 2 == 0) { return false; }
            else if (integer < 9) { return true; }
            else if (integer % 3 == 0) { return false; }
            else
            {
                for (BigInteger i = 5; i < integer; i++)
                {
                    if (integer % i == 0) return false;
                }
            }

            return true;
        }
        public static bool IsPrime(this int integer) => new BigInteger(integer).IsPrime();
        public static bool IsPrime(this long integer) => new BigInteger(integer).IsPrime();
   
        public static BigInteger Sum(this IEnumerable<BigInteger> bigIntegers)
        {
            BigInteger result = 0;
            foreach (var item in bigIntegers)
            {
                result += item;
            }
            return result;
        }    
    
        public static long Mult(this IEnumerable<int> list)
        {
            long result = 1;
            foreach (var item in list)
            {
                result *= item;
            }
            return result;
        }
    
        public static List<T> Move<T>(this List<T> source, int steps)
        {
            if (steps == 0) { return source; }
            else if(steps > 0)
            {
                var result = source.Skip(steps).ToList();
                result.AddRange(source.Take(steps).ToList());
                return result;
            }
            else
            {
                steps = Math.Abs(steps);
                var result = source.TakeLast(steps).ToList();
                result.AddRange(source.SkipLast(steps).ToList());
                return result;
            }
        }

        public static List<List<T>> TakeBy<T>(this List<T> values, int length)
        {
            List<List<T>> result = new List<List<T>>();

            for (int i = 0; i < values.Count - length + 1; i++)
            {
                result.Add(values.Skip(i).Take(length).ToList());
            }

            return result;
        }
    }
}