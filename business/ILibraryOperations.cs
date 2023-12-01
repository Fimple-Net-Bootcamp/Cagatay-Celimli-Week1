using System;
using System.Collections.Generic;

namespace libraryManagementSystem.business
{
    public interface ILibraryOperations
    {
        public void AddBook();
        public void DeleteBook();
        public void BookTolend();
        public void BookToReceive();
    }
}
