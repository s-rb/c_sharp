using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CopyBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            int height;
            int historyScore;
            int mathScore;
            int rusScore;
            double averageScore;

            WriteLine("---------- Записная книжка ----------\nВведите имя:");
            name = ReadLine();

            WriteLine("Введите возраст:");
            age = int.Parse(ReadLine());

            WriteLine("Введите рост:");
            height = int.Parse(ReadLine());

            WriteLine("Введите баллы по истории:");
            historyScore = int.Parse(ReadLine());

            WriteLine("Введите баллы по математике:");
            mathScore = int.Parse(ReadLine());

            WriteLine("Введите данные по русскому языку:");
            rusScore = int.Parse(ReadLine());

            averageScore = GetAverage((double)historyScore, (double)mathScore, (double)rusScore);


            Print(name, age, height, historyScore, mathScore, rusScore, averageScore);
            PrintFormatted(name, age, height, historyScore, mathScore, rusScore, averageScore);
            PrintInterpolated(name, age, height, historyScore, mathScore, rusScore, averageScore);
            PrintInterpolatedCentered(name, age, height, historyScore, mathScore, rusScore, averageScore);
        }

        static double GetAverage(double score1, double score2, double score3)
        {
            return (score1 + score2 + score3) / 3;
        }

        static void Print(string name, int age, int height, int historyScore, int mathScore, int rusScore, double averageScore)
        {
            WriteLine("\n------------------- Обычный вывод ---------------------");
            WriteLine("Имя: " + name + ", возраст: " + age + ", рост: " + height + "\nБаллы:\n\tпо истории: " + historyScore + "\n\tпо математике: " + mathScore + "\n\tпо русскому: " + rusScore + "\n\tсредний балл: " + averageScore);
            ReadKey();
        }

        static void PrintFormatted(string name, int age, int height, int historyScore, int mathScore, int rusScore, double averageScore)
        {
            WriteLine("\n------------------ Форматированный вывод ----------------------");
            string pattern = "Имя: {0}, возраст: {1}, рост: {2}\nБаллы:\n\tпо истории: {3}\n\tпо математике: {4}\n\tпо русскому: {5}\n\tсредний балл: {6}";
            WriteLine(pattern, name, age, height, historyScore, mathScore, rusScore, averageScore);
            ReadKey();
        }

        static void PrintInterpolated(string name, int age, int height, int historyScore, int mathScore, int rusScore, double averageScore)
        {
            WriteLine("\n------------------ Интерполированный вывод ----------------------");
            string pattern = $"Имя: {name}, возраст: {age}, рост: {height}\nБаллы:\n\t{"по истории: ",15}{historyScore}\n\t{"по математике: ", 15}{mathScore}\n\t{"по русскому: ",15}{rusScore}\n\t{"средний балл: ",15}{averageScore:0.00}";
            WriteLine(pattern);
            ReadKey();
        }

        static void PrintInterpolatedCentered(string name, int age, int height, int historyScore, int mathScore, int rusScore, double averageScore)
        {
            int center = WindowWidth / 2;
            WriteLine("\n------------------ Вывод в центре консоли ----------------------");
            string message1 = $"Имя: {name}, возраст: {age}, рост: {height}";
            string message2 = $"Баллы: по истории: {historyScore} по математике: {mathScore} по русскому: {rusScore}";
            string message3 = $"средний балл: {averageScore:0.00}";
            Console.SetCursorPosition(center, CursorTop);
            WriteLine(message1);
            Console.SetCursorPosition(center, CursorTop);
            WriteLine(message2);
            Console.SetCursorPosition(center, CursorTop);
            WriteLine(message3);
            ReadKey();
        }
    }
}
