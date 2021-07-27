using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CA_ProjectEuler
{
    public static class Extra
    {
        public static List<int> Sublist(this List<int> Lista, int startIndex, int length)
        {
            List<int> resultado = new List<int>();

            for (int i = startIndex; i < (startIndex + length); i++)
            {
                resultado.Add(Lista.ElementAt(i));
            }

            return resultado;
        }

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
    
    }
}