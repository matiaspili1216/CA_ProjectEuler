using System;
using System.Reflection;

namespace CA_ProjectEuler
{
    static class Program
    {
        static readonly int MaxProblem = 35;
        static void Main()
        {
            int problem = GetNumberProblem();

            Type thisType = typeof(Problems);
            MethodInfo theMethod = thisType.GetMethod($"Problem{problem}");
            var Rta = theMethod.Invoke(thisType, null);

            Console.WriteLine(Rta);

            Console.ReadLine();
        }

        private static int GetNumberProblem()
        {
            Console.WriteLine($"Select number of problem [1 to {MaxProblem}]:");

            do
            {
                string ans = Console.ReadLine();

                if (int.TryParse(ans, out int result))
                {
                    if (result < 1 || result > MaxProblem)
                    {
                        Console.WriteLine($"Select number of problem from 1 to {MaxProblem}:");
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine($"'{ans}' is not a number.\n\nSelect number of problem [1 to {MaxProblem}]:\n");
                }

            } while (true);
        }


    }
}