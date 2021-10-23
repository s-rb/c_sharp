using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGameApp
{
    class Program
    {

        /*Задание:
            Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

             Требуемый опыт работы: без опыта
             Частичная занятость, удалённая работа

             Описание


             Стартап «Micarosppoftle» занимающийся разработкой
             многопользовательских игр ищет разработчиков в свою команду.
             Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
             но желающих развиваться в сфере разработки игр на платформе.NET.

             Должность Интерн C#/
            
             Основные требования:
            C#, операторы ввода и вывода данных, управляющие конструкции 
             
             Конкурентным преимуществом будет знание процедурного программирования.


             Не технические требования:
            английский на уровне понимания документации и справочных материалов


             В качестве тестового задания предлагается решить следующую задачу.


             Написать игру, в которою могут играть два игрока.
             При старте, игрокам предлагается ввести свои никнеймы.
             Никнеймы хранятся до конца игры.
             Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
             Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
             Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
             введенное число вычитается из gameNumber
             Новое значение gameNumber показывается игрокам на экране.
             Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
             Игра поздравляет победителя, предлагая сыграть реванш

             * Бонус:
             Подумать над возможностью реализации разных уровней сложности.
             В качестве уровней сложности может выступать настраиваемое, в начале игры,
             значение userTry, изменение диапазона gameNumber, или указание большего количества игроков(3, 4, 5...)

             ***Сложный бонус
            Подумать над возможностью реализации однопользовательской игры
            т е игрок должен играть с компьютером


             Демонстрация
             Число: 12,
             Ход User1: 3


             Число: 9
             Ход User2: 4


             Число: 5
             Ход User1: 2


             Число: 3
             Ход User2: 3


             User2 победил!*/

        static void Main(string[] args)
        {

            Console.WriteLine("Игра Угадай-ка. Начало");
            Console.WriteLine("Игрок 1 введите имя");
            string user1Name = Console.ReadLine();
            Console.WriteLine("Игрок 2 введите имя");
            string user2Name = Console.ReadLine();


            int gameNumber = new Random().Next(12, 121);
            Console.WriteLine($"Загадано число: {gameNumber}");
            string infoMsg = "Требуется вводить числа 1, 2, 3, 4, которые меньше или равны загаданного числа";
            Console.WriteLine(infoMsg);

            int userTry;

            while (gameNumber != 0)
            {
                userTry = GetValidUserTry(user1Name, infoMsg, gameNumber);
                gameNumber -= userTry;
                if (gameNumber == 0)
                {
                    Console.WriteLine($"Игра окончена, {user1Name} - победитель!");
                    break;
                }
                else
                {
                    Console.WriteLine($"gameNumber: {gameNumber}");
                }

                userTry = GetValidUserTry(user2Name, infoMsg, gameNumber);
                gameNumber -= userTry;
                if (gameNumber == 0)
                {
                    Console.WriteLine($"Игра окончена, {user2Name} - победитель!");
                    break;
                }
                else
                {
                    Console.WriteLine($"gameNumber: {gameNumber}");
                }
            }
            Console.ReadKey();
        }

        static int GetValidUserTry(string userName, string infoMsg, int gameNumber)
        {
            Console.WriteLine($"{userName} введите число");
            int userTry = 0;
            bool isValid = false;
            while (!isValid)
            {
                userTry = int.Parse(Console.ReadLine());
                isValid = IsUserTryValid(userTry, gameNumber);
                if (isValid) return userTry;
                Console.WriteLine(infoMsg);
            }
            return 0;
        }

        static bool IsUserTryValid(int userTry, int gameNumber)
        {
            return userTry >= 1 && userTry <= 4 && userTry <= gameNumber;
        }
    }
}
