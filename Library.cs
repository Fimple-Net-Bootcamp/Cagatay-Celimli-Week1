using libraryManagementSystem.business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryManagementSystem
{
    public class Library
    {
        ILibraryOperations _operations;
        bool isExit = false;

        public Library(ILibraryOperations operations)
        {
            _operations = operations;
        }

        public void ApplicationStart()
        {
            try
            {
                while (!isExit)
                {
                    repeat:
                    Console.WriteLine("|**************** Kütüphane Yönetim Sistemi *****************|");
                    Console.WriteLine(" (1) Kütüphane Kitap Ekle");
                    Console.WriteLine(" (2) Kütüphane Kitap Sil");
                    Console.WriteLine(" (3) Kitap Ödünç Ver");
                    Console.WriteLine(" (4) Kitap Teslim al");
                    Console.WriteLine(" (0) Çıkış Yap");
                    Console.Write("Yapmak İstediğiniz işlemi Seçiniz : ");
                    int choose = Convert.ToInt32(Console.ReadLine());

                    switch (choose)
                    {
                        case 0:
                            this.isExit = true;
                            Console.WriteLine("Çıkış Yapıldı...");
                            break;
                        case 1:
                            this._operations.AddBook();
                            break;
                        case 2:
                            this._operations.DeleteBook();
                            break;
                        case 3:
                            this._operations.BookTolend();
                            break;
                        case 4:
                            this._operations.BookToReceive();
                            break;
                        default:
                            Console.WriteLine("Doğru bir seçim yapınız!");
                            goto repeat;
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception : {exception.Message}");
            }
        }
    }
}
