using libraryManagementSystem.business;
using System;

namespace libraryManagementSystem
{
    class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library(new LibraryOperationsManager());
            library.ApplicationStart();
        }
    }
}