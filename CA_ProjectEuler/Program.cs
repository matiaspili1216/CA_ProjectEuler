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

            string ans = GetAnswer(problem);
            bool isCorrect = Rta.ToString().Equals(ans);

            Console.WriteLine($"{Rta} [{(isCorrect ? "CORRECT" : "INCORRECT")}]");
            if(!isCorrect) { Console.WriteLine($"{ans} [CORRECT]"); }

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

        private static string GetAnswer(int problem)
        {
            switch (problem)
            {
                case 1: return "233168";
                case 2: return "4613732";
                case 3: return "6857";
                case 4: return "906609";
                case 5: return "232792560";
                case 6: return "25164150";
                case 7: return "104743";
                case 8: return "23514624000";
                case 9: return "31875000";
                case 10: return "142913828922";
                case 11: return "70600674";
                default: return "";
            }
        }
    }
}