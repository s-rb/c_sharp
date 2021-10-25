using System;

namespace TriangleNumbersApp
{
    class Program
    {
        /*
         * Задание 2
         Заказчику требуется приложение строящее первых N строк треугольника паскаля.N < 25


         При N = 9.Треугольник выглядит следующим образом:
                                         1
                                     1       1
                                 1       2       1
                             1       3       3       1
                         1       4       6       4       1
                     1       5      10      10       5       1
                 1       6      15      20      15       6       1
             1       7      21      35      35       21      7       1



         Простое решение:                                                             
         1
         1       1
         1       2       1
         1       3       3       1
         1       4       6       4       1
         1       5      10      10       5       1
         1       6      15      20      15       6       1
         1       7      21      35      35       21      7       1


         Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля


         */
        static void Main(string[] args)
        {
            int triangleSize = 9;

            var pascaleTriangle = CreatePascaleTriangle(triangleSize);

            foreach (var arr in pascaleTriangle)
            {
                string message = "";
                foreach (var num in arr)
                {
                    if (message == "")
                    {
                        message += num;
                    }
                    else
                    {
                        message += ("\t" + num);
                    }
                }

                Console.WriteLine(message);
            }

            Console.ReadKey();
        }

        private static int[][] CreatePascaleTriangle(int size)
        {
            int[][] pascaleTriangle = new int[size][];
            for (int i = 0; i < size; i++)
            {
                if (i == 0)
                {
                    pascaleTriangle[i] = new int[] { 1 };
                }
                else if (i == 1)
                {
                    pascaleTriangle[i] = new int[] { 1, 1 };
                }
                else
                {
                    int[] temp = new int[i + 1];
                    for (int j = 0; j < (i + 1); j++)
                    {
                        if (j == 0 || j == (i))
                        {
                            temp[j] = 1;
                        }
                        else
                        {
                            temp[j] = pascaleTriangle[i - 1][j - 1] + pascaleTriangle[i - 1][j];
                        }
                    }

                    pascaleTriangle[i] = temp;
                }
            }

            return pascaleTriangle;
        }
    }
}