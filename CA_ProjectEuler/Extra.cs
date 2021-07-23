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
    }
}