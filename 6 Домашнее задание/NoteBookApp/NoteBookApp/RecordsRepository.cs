using System;
using static System.Console;

namespace NoteBookApp.Properties
{
    public class RecordsRepository
    {
        private static int IdGenerator = 0;
        
        private int count = 0;
        private Record[] records = new Record[50];

        public Record FindById(int id)
        {
            WriteLine($"### В FindById ищем запись по ИД: {id}");
            Record res = null;
            for (int i = 0; i < count; i++)
            {
                Record record = records[i];
                if (record.id == id)
                {
                    WriteLine($"### В FindById найдена запись: {record.ToString()}");
                    return record;
                }
            }

            WriteLine($"### В FindById не найдено записей с ИД: {id}");
            return res;
        }

        public Record[] FindAll()
        {
            Record[] res = new Record[count];
            for (int i = 0; i < count; i++)
            {
                res[i] = records[i];
            }
            WriteLine($"### В FindAll найдено записей: {count}");
            return res;
        }

        public Record Create(Record rec)
        {
            if (count == records.Length)
            {
                WriteLine($"### В Create количество записей достигло предела. Увеличиваем массив");
                Expand();
            }

            rec.id = NextId();

            records[count++] = rec;
            WriteLine($"### В Create создана новая запись: {rec.ToString()}");
            PrintCount();
            return rec;
        }

        public bool DeleteById(int id)
        {
            WriteLine($"### В DeleteById удаляется запись по ИД: {id}");
            for (int i = 0; i < count; i++)
            {
                Record rec = records[i];
                if (rec.id == id)
                {
                    // удалить элемент и сдвинуть все элементы влево (физически элемент не удаляется)
                    for (int j = i; j < count - 1; j++)
                    {
                        records[j] = records[j + 1];
                    }
                    count--;
                    WriteLine($"### В DeleteById успешно удалена запись по ИД: {id}");
                    PrintCount();
                    return true;
                }
            }
            WriteLine($"### В DeleteById не удалось удалить запись по ИД: {id}");
            PrintCount();
            return false;
        }

        public bool Delete(Record rec)
        {
            WriteLine($"### В Delete удаляется запись: {rec}");
            for (int i = 0; i < count; i++)
            {
                Record current = records[i];
                if (current.id == rec.id)
                {
                    // удалить элемент и сдвинуть все элементы влево (физически элемент не удаляется)
                    for (int j = i; j < count - 1; j++)
                    {
                        records[j] = records[j + 1];
                    }
                    count--;
                    WriteLine($"### В Delete успешно удалена запись: {current}");
                    PrintCount();
                    return true;
                }
            }
            WriteLine($"### В Delete не удалось удалить запись: {rec}");
            PrintCount();
            return false;
        }

        public bool Update(Record rec)
        {
            WriteLine($"### В Update обновляется запись: {rec}");
            for (int i = 0; i < count; i++)
            {
                Record current = records[i];
                if (current.id == rec.id)
                {
                    records[i] = rec;
                    WriteLine($"### В Update успешно обновлена запись: {current} на {rec}");
                    return true;
                }
            }
            WriteLine($"### В Update не удалось обновить никакую запись на: {rec}");
            return false;
        }

        private static int NextId()
        {
            WriteLine($"### В NextId текущий ИД: {IdGenerator}");
            return IdGenerator++;
        }

        private void Expand()
        {
            var recordsLength = records.Length;
            WriteLine($"### В Expand текущий размер массива: {recordsLength}");
            var newLength = (int)(recordsLength * 1.5);
            WriteLine($"### В Expand новый размер массива: {newLength}");
            Record[] res = new Record[newLength];
            Array.Copy(records, res, recordsLength);
            records = res;
        }

        public void PrintCount()
        {
            WriteLine($"В репозитории {count} записей");
        }
    }
}