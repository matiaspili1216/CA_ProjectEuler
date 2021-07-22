using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CA_ProjectEuler
{
    public static class Extra
    {
        public static string RemoveChars(this string value, params char[] charsRemove)
        {
            foreach (var charRemove in charsRemove)
            {
                value.Replace(charRemove.ToString(), "");
            }

            return value;
        }

        public static char ToLower(this char value) => char.ToLower(value, new System.Globalization.CultureInfo("es-AR", false));

        public static char ToUpper(this char value) => char.ToUpper(value, new System.Globalization.CultureInfo("es-AR", false));

        public static List<int> Sublist(this List<int> Lista, int startIndex, int length)
        {
            List<int> resultado = new List<int>();

            for (int i = startIndex; i < (startIndex + length); i++)
            {
                resultado.Add(Lista.ElementAt(i));
            }

            return resultado;
        }

        public static List<string> RemoveInValues(this List<string> Lista, params char[] charRemove)
        {
            List<string> ListResult = new List<string>();

            for (int i = 0; i < Lista.Count; i++)
            {
                ListResult.Add(Lista.ElementAt(i).RemoveChars(charRemove));
            }

            return ListResult;
        }
    }
}
