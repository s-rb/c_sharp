using System;

namespace NoteBookApp
{
    public class Record
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dateTime { get; private set; }
        public string author { get; set; }

        public Record(string title, string description, string author)
        {
            this.title = title;
            this.description = description;
            this.author = author;
            this.dateTime = DateTime.Now;
        }

        public Record(string title, string description) : this(title, description, String.Empty){
        }

        public override string ToString()
        {
            return $"[id: {id}, title: '{title}', description: '{description}', dateTime: '{dateTime.ToString()}', author: '{author}]'";
        }
    }
}