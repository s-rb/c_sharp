using System;
using static System.Console;

namespace NoteBookApp
{
    internal class Program
    {
        private static NoteBook noteBook;

        public static void Main(string[] args)
        {
            noteBook = new NoteBook();
            WriteLine("Приветствую. Записная книжка создана\nСправка доступна по команде 'help'");
            Work();
        }

        private static void Work()
        {
            WriteLine("Введите команду:");
            while (true)
            {
                string command = ReadLine();
                if (!string.IsNullOrEmpty(command))
                {
                    ExecuteCommand(command);
                }
            }
        }

        private static void ExecuteCommand(string command)
        {
            switch (command.ToLower())
            {
                case "help":
                case "h":
                {
                    string showAll = "Показать все записи: 'show all'";
                    string show = "Показать запись: 'show'";
                    string create = "Создать запись: 'new'";
                    string update = "Обновить запись: 'update'";
                    string delete = "Удалить запись: 'delete'";
                    string cancel = "Отменить текущую операцию: 'cancel'";
                    string help = "Помощь: 'help'";
                    string exit = "Выход: 'exit'";
                    WriteLine($"Доступные команды:\n\t-{showAll},\n\t-{show},\n\t-{create},\n\t-{update}," +
                              $"\n\t-{delete},\n\t-{cancel},\n\t-{help},\n\t-{exit}");
                    break;
                }

                case "show all":
                {
                    noteBook.ReadAllRecords();
                    break;
                }

                case "show":
                {
                    WriteLine($"Введите ИД записи, которую желаете просмотреть: ");
                    while (true)
                    {
                        string cmd = ReadLine();
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            if (cmd.ToLower().Equals("cancel")) break;
                            bool isExecuted = ExecuteShowCommand(cmd);
                            if (isExecuted) break;
                        }
                    }

                    break;
                }

                case "create":
                {
                    ExecuteCreate();
                    break;
                }

                case "update":
                {
                    WriteLine($"Введите ИД записи, которую желаете обновить: ");
                    while (true)
                    {
                        string cmd = ReadLine();
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            if (cmd.ToLower().Equals("cancel")) break;
                            bool isExecuted = ExecuteUpdate(cmd);
                            if (isExecuted) break;
                        }
                    }

                    break;
                }

                case "delete":
                case "del":
                {
                    WriteLine($"Введите ИД записи, которую желаете удалить: ");
                    while (true)
                    {
                        string cmd = ReadLine();
                        if (!string.IsNullOrEmpty(cmd))
                        {
                            if (cmd.ToLower().Equals("cancel")) break;
                            bool isExecuted = ExecuteDeleteCommand(cmd);
                            if (isExecuted) break;
                        }
                    }

                    break;
                }

                case "exit":
                {
                    Environment.Exit(0);
                    break;
                }
                default:
                    WriteLine("Команда не распознана");
                    break;
            }
        }

        private static bool ExecuteDeleteCommand(string cmd)
        {
            int parsedId;
            bool isParsed = int.TryParse(cmd, out parsedId);
            if (isParsed)
            {
                noteBook.DeleteById(parsedId);
                return true;
            }

            WriteLine("Команда не распознана. Введите ИД или отмените - 'cancel'");
            return false;
        }

        private static bool ExecuteUpdate(string command)
        {
            int parsedId;
            bool isParsed = int.TryParse(command, out parsedId);
            if (!isParsed)
            {
                WriteLine("Команда не распознана. Введите ИД или отмените - 'cancel'");
                return false;
            }

            WriteLine("Введите заголовок записи");
            string title;
            while (true)
            {
                title = ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    WriteLine("Заголовок не может быть пустым");
                }
                else
                {
                    break;
                }
            }

            WriteLine("Введите описание записи");
            string descr;
            while (true)
            {
                descr = ReadLine();
                if (string.IsNullOrEmpty(descr))
                {
                    WriteLine("Описание не может быть пустым");
                }
                else
                {
                    break;
                }
            }

            WriteLine("Введите автора записи (опционально)");
            string author = ReadLine();

            var updated = noteBook.Update(parsedId, title, descr, author);

            return true;
        }

        private static void ExecuteCreate()
        {
            WriteLine("Введите заголовок записи");
            string title;
            while (true)
            {
                title = ReadLine();
                if (string.IsNullOrEmpty(title))
                {
                    WriteLine("Заголовок не может быть пустым");
                }
                else
                {
                    break;
                }
            }

            WriteLine("Введите описание записи");
            string descr;
            while (true)
            {
                descr = ReadLine();
                if (string.IsNullOrEmpty(descr))
                {
                    WriteLine("Описание не может быть пустым");
                }
                else
                {
                    break;
                }
            }

            WriteLine("Введите автора записи (опционально)");
            string author = ReadLine();

            var saved = noteBook.CreateRecord(title, descr, author);
        }

        private static bool ExecuteShowCommand(string showCommand)
        {
            int parsedId;
            bool isParsed = int.TryParse(showCommand, out parsedId);
            if (isParsed)
            {
                noteBook.ReadById(parsedId);
                return true;
            }

            WriteLine("Команда не распознана. Введите ИД или отмените - 'cancel'");
            return false;
        }
    }
}