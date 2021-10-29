using System;
using static System.Console;

namespace MethodTestTextApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string srcText = "А ББ ВВВ ГГГГ ДДДД ДД ЕЕ ЖЖ ЗЗЗ";
            WriteLine($"Src Text: '{srcText}'");
            WriteLine($"Shortest word: '{GetShortestWord(srcText)}'");
            WriteLine($"Longest words: '{GetString(GetLongestWords(srcText))}'");

            WriteLine("------------ Remove Duplicate Symbols --------------");
            var duplicateText = "ПППОООГГГГОООДДДАА";
            WriteLine($"Src text with duplicates: '{duplicateText}' ===> '{RemoveDuplicateSymbols(duplicateText)}'");

            WriteLine("---------------- Is Progression ----------------------");
            int[] sequence = new[] { 1, 2, 3, 4 };
            WriteLine($"Sequence 1: [{GetString(sequence)}] - это {IsSequence(sequence)}");
            int[] sequence2 = new[] { 1, 3, 9, 27 };
            WriteLine($"Sequence 2: [{GetString(sequence2)}] - это {IsSequence(sequence2)}");
            int[] sequence3 = new[] { 1, 2, 2, 9 };
            WriteLine($"Sequence 3: [{GetString(sequence3)}] - это {IsSequence(sequence3)}");
            
            WriteLine("-------------------- Akkermann ----------------------");
            WriteLine($"Исходные данные: m = 1 и n = 2. Результат: {CalculateAkkermann(1, 2)}");
            WriteLine($"Исходные данные: m = 2 и n = 3. Результат: {CalculateAkkermann(2, 3)}");
            WriteLine($"Исходные данные: m = 3 и n = 2. Результат: {CalculateAkkermann(3, 2)}");
            WriteLine($"Исходные данные: m = 3 и n = 7. Результат: {CalculateAkkermann(3, 7)}");

            ReadKey();
        }

        public static string GetShortestWord(string text)
        {
            var words = GetSortedWords(text);
            return words[0];
        }

        public static string[] GetLongestWords(string text)
        {
            string[] res;

            var words = GetSortedWords(text);
            int maxLengthWordsCount = 0;
            int maxLength = words[words.Length - 1].Length;
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (words[i].Length == maxLength) maxLengthWordsCount++;
            }

            res = new string[maxLengthWordsCount];

            for (int i = words.Length - 1, j = 0; j < maxLengthWordsCount; j++)
            {
                res[j] = words[i - j];
            }

            return res;
        }

        public static string RemoveDuplicateSymbols(string text)
        {
            string res = "";
            char last = '\0';

            for (int i = 0; i < text.Length; i++)
            {
                var current = text[i];

                if (i == 0)
                {
                    res += current;
                    last = current;
                    continue;
                }

                if (last == current) continue;

                res += current;
                last = current;
            }

            return res;
        }

        public static string IsSequence(int[] src)
        {
            bool isArithmetic = IsArithmetic(src);
            bool isGeometric = IsGeometric(src);
            if (isArithmetic) return "Арифметическая прогрессия";
            if (isGeometric) return "Геометрическая прогрессия";
            return "Не прогрессия";
        }

        public static int CalculateAkkermann(int m, int n)
        {
            if (m < 0 || n < 0) throw new ArgumentException("Параметры m и n должны быть неотрицательными");
            if (m == 0) return n + 1;
            if (n == 0) return CalculateAkkermann(m - 1, 1);
            return CalculateAkkermann(m - 1, CalculateAkkermann(m, n - 1));
        }

        private static bool IsArithmetic(int[] src)
        {
            if (src.Length < 2) return false;
            int diff = src[1] - src[0];
            for (int i = 1; i < src.Length - 2; i++)
            {
                int temp = src[i + 1] - src[i];
                if (temp != diff) return false;
            }

            return true;
        }

        private static bool IsGeometric(int[] src)
        {
            if (src.Length < 2 || src[1] % src[0] != 0) return false;
            int diff = src[1] / src[0];
            for (int i = 1; i < src.Length - 2; i++)
            {
                int temp = src[i + 1] / src[i];
                if (temp != diff || src[i + 1] % src[i] != 0) return false;
            }

            return true;
        }

        private static string[] GetSortedWords(string text)
        {
            var strings = text.Split(' ', '.', ',');
            Array.Sort(strings, (o1, o2) => o1.Length - o2.Length);
            return strings;
        }

        private static string GetString(string[] src)
        {
            return string.Join(", ", src);
        }

        private static string GetString(int[] src)
        {
            return string.Join(", ", src);
        }
    }
}