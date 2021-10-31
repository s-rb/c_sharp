using NoteBookApp.Properties;
using static System.Console;

namespace NoteBookApp
{
    public class NoteBook
    {
        private RecordsRepository repository = new RecordsRepository();

        public Record[] ReadAllRecords()
        {
            var all = repository.FindAll();
            repository.PrintCount();
            foreach (var rec in all)
            {
                WriteLine(rec);
            }

            return all;
        }

        public Record CreateRecord(string title, string description, string author)
        {
            Record rec = new Record(title, description, author);
            return repository.Create(rec);
        }

        public Record ReadById(int id)
        {
            return repository.FindById(id);
        }

        public bool Update(int id, string title, string description, string author)
        {
            Record newRec = new Record(title, description, author);
            newRec.id = id;
            return repository.Update(newRec);
        }

        public bool DeleteById(int id)
        {
            return repository.DeleteById(id);
        }
    }
}