using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryManagementSystem.entity
{
    public class BookDTO
    {
        private static int lastBookId = 0;
        private int id;
        private string name;
        private string author;
        private string releaseYear;

        public BookDTO(string _name, string _author, string _releaseYear)
        {
            this.id = ++lastBookId;
            this.name = _name;
            this.author = _author;
            this.releaseYear = _releaseYear;
        }

        public static int LastId { set => lastBookId = value; }
        public int Id { get => id; }
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string ReleaseYear { get => releaseYear; set => releaseYear = value; }
    }
}
