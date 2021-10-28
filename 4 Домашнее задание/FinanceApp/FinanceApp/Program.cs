using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    class Program
    {
        /*Задание 1.
         Заказчик просит вас написать приложение по учёту финансов
         и продемонстрировать его работу.
         Суть задачи в следующем: 
         Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств.
         За год получены два массива – расходов и поступлений.
         Определить прибыли по месяцам
         Количество месяцев с положительной прибылью.
         Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью,
         если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
         Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

         Пример


         Месяц Доход, тыс. руб.Расход, тыс.руб.Прибыль, тыс.руб.
             1              100 000             80 000                 20 000
             2              120 000             90 000                 30 000
             3               80 000             70 000                 10 000
             4               70 000             70 000                      0
             5              100 000             80 000                 20 000
             6              200 000            120 000                 80 000
             7              130 000            140 000 - 10 000
             8              150 000             65 000                 85 000
             9              190 000             90 000                100 000
            10              110 000             70 000                 40 000
            11              150 000            120 000                 30 000
            12              100 000             80 000                 20 000


         Худшая прибыль в месяцах: 7, 4, 1, 5, 12
         Месяцев с положительной прибылью: 10
*/
        static void Main(string[] args)
        {
            int[] incomeArray =
                { 100000, 120000, 180000, 70000, 100000, 200000, 130000, 150000, 190000, 110000, 150000, 100000 };
            int[] expenseArray =
                { 80000, 90000, 70000, 70000, 80000, 120000, 140000, 65000, 90000, 70000, 120000, 80000 };
            int[] profitArray = new int[12];
            string[] months =
            {
                "январь", "февраль", "март", "апрель", "май", "июнь", "июль", "август", "сентябрь", "октябрь", "ноябрь",
                "декабрь"
            };
            int NUMBER_OF_WORST_PROFITS = 3;

            // Определяем и выводим прибыли
            Console.WriteLine($"{"Месяц",15}{"Доход, тыс.руб.",20}{"Расход, тыс.руб.",20}{"Прибыль, тыс.руб.",20}");
            for (int i = 0; i < 12; i++)
            {
                profitArray[i] = incomeArray[i] - expenseArray[i];
                Console.WriteLine($"{months[i],15}{incomeArray[i],20}{expenseArray[i],20}{profitArray[i],20}");
            }

            // Находим и выводим месяцы с положительной прибылью
            int positiveProfitMonths = 0;
            int[] worstProfitsArray = new int[NUMBER_OF_WORST_PROFITS];

            for (int i = 0; i < 12; i++)
            {
                int profit = profitArray[i];
                if (profit > 0)
                {
                    positiveProfitMonths++;
                }
            }
            Console.WriteLine($"Месяцев с положительной прибылью: {positiveProfitMonths}");
            
            int[] profitArraySorted = new int[profitArray.Length];
            Array.Copy(profitArray, profitArraySorted, profitArray.Length);
            Array.Sort(profitArraySorted);

            // Находим заданное количество худших прибылей (не повторяясь)
            for (int i = 0; i < NUMBER_OF_WORST_PROFITS; i++)
            {
                int worstProfit = profitArraySorted[i]; // Запоминаем базовый профит
                int k = i + 1;
                while (i != 0 && Array.IndexOf(worstProfitsArray, worstProfit) != -1)
                {
                    worstProfit = profitArraySorted[k++];
                }

                worstProfitsArray[i] = worstProfit;
            }
            
            // На основании запомненных профитов, составляем строку вывода с месяцами с такими профитами
            string worstProfitMonthString = "";
            for (int i = 0; i < profitArray.Length; i++)
            {
                int currentProfit = profitArray[i];
                foreach (var currentWorstProfit in worstProfitsArray)
                {
                    if (currentProfit != currentWorstProfit) continue;
                    if (worstProfitMonthString == "")
                    {
                        worstProfitMonthString += (i + 1);
                    }
                    else
                    {
                        worstProfitMonthString += (", " + (i + 1));
                    }
                }
            }

            Console.WriteLine($"Худшая прибыль в месяцах: {worstProfitMonthString}");
            Console.ReadKey();
        }
    }
}