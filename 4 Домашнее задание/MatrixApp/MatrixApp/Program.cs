using System;

namespace MatrixApp
{
    class Program
    {
        /*
         *Задание 3.1
         Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
         Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
         Добавить возможность ввода количество строк и столцов матрицы и число,
         на которое будет производиться умножение.
         Матрицы заполняются автоматически.
         Если по введённым пользователем данным действие произвести невозможно -сообщить об этом


         Пример

              | 1  3  5 |   | 5  15  25 |
          5 х | 4  5  7 | = | 20  25  35 |
              | 5  3  1 |   | 25  15   5 |


     **Задание 3.2
         Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
         Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
         Добавить возможность ввода количество строк и столцов матрицы.
         Матрицы заполняются автоматически
         Если по введённым пользователем данным действие произвести невозможно - сообщить об этом


         Пример
            | 1  3  5 |   | 1  3  4 |   | 2   6   9 |
    
            | 4  5  7 | + | 2  5  6 | = | 6  10  13 |

            | 5  3  1 |   | 3  6  7 |   | 8   9   8 |



            | 1  3  5 |   | 1  3  4 |   | 0   0   1 |

            | 4  5  7 | - | 2  5  6 | = | 2   0   1 |

            | 5  3  1 |   | 3  6  7 |   | 2 - 3 - 6 |

        ***Задание 3.3
         Заказчику требуется приложение позволяющщее перемножать математические матрицы
         Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
        Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
         Добавить возможность ввода количество строк и столцов матрицы.
         Матрицы заполняются автоматически
         Если по введённым пользователем данным действие произвести нельзя - сообщить об этом


          | 1  3  5 |   | 1  3  4 |   | 22  48  57 |

         | 4  5  7 | х | 2  5  6 | = | 35  79  95 |

        | 5  3  1 |   | 3  6  7 |   | 14  36  45 |



                           | 4 |

             | 1  2  3 | х | 5 | = | 32 |

                           | 6 |

         */
        public static void Main(string[] args)
        {
            int[][] srcMatrix =
            {
                new int[] { 1, 3, 5 },
                new int[] { 4, 5, 7 },
                new int[] { 5, 3, 1 }
            };
            int[][] multipliedMatrix = GetMultiplied(srcMatrix, 5);
            Console.WriteLine("------------ Multiplied Matrix -------------");
            PrintMatrix(multipliedMatrix);

            int[][] addMatrix =
            {
                new int[] { 1, 3, 4 },
                new int[] { 2, 5, 6 },
                new int[] { 3, 6, 7 }
            };
            int[][] afterAddMatrix = GetAdded(srcMatrix, addMatrix, false);
            Console.WriteLine("------------ Add Matrix Left -------------");
            PrintMatrix(srcMatrix);

            Console.WriteLine("------------ Add Matrix Left -------------");
            PrintMatrix(addMatrix);

            Console.WriteLine("------------ Add Matrix Result -------------");
            PrintMatrix(afterAddMatrix);


            int[][] resMultipliedMatrix = GetMultiplied(srcMatrix, addMatrix);
            Console.WriteLine("------------ Multiplied Matrix Result -------------");
            PrintMatrix(resMultipliedMatrix);
            
            // second try
            int[][] firstMult =
            {
                new int[]{1, 2, 3}
            };
            int[][] secondMult =
            {
                new int[]{4},
                new int[]{5},
                new int[]{6}
            };
            int[][] res2MultipliedMatrix = GetMultiplied(firstMult, secondMult);
            Console.WriteLine("------------ Multiplied Matrix 2 Result -------------");
            PrintMatrix(res2MultipliedMatrix);

            Console.ReadKey();
        }

        private static int[][] GetMultiplied(int[][] first, int[][] second)
        {
            int[][] res = new int[first.Length][];
            for (int i = 0; i < first.Length; i++)
            {
                int[] row = new int[second[i].Length];
                for (int j = 0; j < first.Length; j++)
                {
                    int element = 0;
                    for (int k = 0; k < second.Length; k++)
                    {
                        var i1 = first[i][k];
                        var i2 = second[k][j];
                        element += i1 * i2;
                    }
                    
                    row[j] = element;
                }

                res[i] = row;
            }

            return res;
        }

        private static int[][] GetAdded(int[][] first, int[][] second, bool hasToSubtract)
        {
            int[][] res = new int[first.Length][];
            for (int i = 0; i < first.Length; i++)
            {
                int[] row = new int[first[i].Length];
                for (int j = 0; j < first.Length; j++)
                {
                    row[j] = !hasToSubtract ? (first[i][j] + second[i][j]) : (first[i][j] - second[i][j]);
                }

                res[i] = row;
            }

            return res;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                string message = "";
                foreach (var element in row)
                {
                    if (message == "")
                    {
                        message += element;
                    }
                    else
                    {
                        message += (" " + element);
                    }
                }

                Console.WriteLine("|" + message + "|");
            }
        }

        private static int[][] GetMultiplied(int[][] srcMatrix, int multyplier)
        {
            int[][] res = new int[srcMatrix.Length][];
            for (int i = 0; i < srcMatrix.Length; i++)
            {
                int[] row = new int[srcMatrix[i].Length];
                for (int j = 0; j < srcMatrix.Length; j++)
                {
                    var element = srcMatrix[i][j];
                    row[j] = element * multyplier;
                }

                res[i] = row;
            }

            return res;
        }
    }
}