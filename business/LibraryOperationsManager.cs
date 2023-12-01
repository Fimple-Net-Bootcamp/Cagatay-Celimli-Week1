using libraryManagementSystem.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace libraryManagementSystem.business
{
    internal class LibraryOperationsManager : ILibraryOperations
    {
        List<BookDTO> books = new List<BookDTO>();
        List<MemberDTO> members = new List<MemberDTO>();

        public LibraryOperationsManager() 
        {
            members.Add(new MemberDTO("Cagatay", "Celimli", 1010));
            members.Add(new MemberDTO("Tayyip", "Celimli", 3434));
            members.Add(new MemberDTO("Salih", "Kaplan", 3401));

            books.Add(new BookDTO("Book 1", "Author 1", "2000"));
            books.Add(new BookDTO("Book 2", "Author 2", "2002"));
            books.Add(new BookDTO("Book 3", "J.K Rowling", "2004"));
        }
        public void AddBook()
        {
            try
            {
            repeat:
                Console.WriteLine("|************************ Kitap Ekle ************************|");
                Console.Write("Eklenecek kitabın adını girin : ");
                string bookName = Console.ReadLine();
                Console.Write("Eklenecek kitabın yazarını girin : ");
                string bookAuthor = Console.ReadLine();
                Console.Write("Eklenecek kitabın yayın yılını girin : ");
                string bookRelease = Console.ReadLine();

                Console.WriteLine("Girilen bilgilerinin doğru olduğunu onaylıyor musunuz ?");
                Console.WriteLine($"(1) Evet, Kaydet\n(2) Kayıttan Vazgeç\n(3) Bilgileri Düzelt");
                int choose = Convert.ToInt32(Console.ReadLine());

                switch (choose)
                {
                    case 1:
                        BookDTO book = new BookDTO(bookName, bookAuthor, bookRelease);
                        books.Add(book);
                        Console.WriteLine($"{book.Name} adlı kitap kaydedildi");
                        break;
                    case 2:
                        Console.WriteLine("Kayıt iptal edildi.");
                        return;
                    case 3:
                        goto repeat;
                    default:
                        Console.WriteLine("Lütfen bilgileri doğru giriniz!!!");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }

        public void BookToReceive()
        {
            try
            {
                repeat:
                Operations.WriteMembers(members);
                Console.Write("Kitap teslim edecek üyenin id numarasını girin : ");
                int memberId = Convert.ToInt32(Console.ReadLine().Trim());
                int memberIndex = members.FindIndex((member) => member.Id == memberId);

                Operations.WriteBooks(members[memberIndex].BorrowedBooks);
                Console.Write("Teslim edilecek kitabın id numarasını girin : ");
                int bookId = Convert.ToInt32(Console.ReadLine().Trim());
                int bookIndex = members[memberIndex].BorrowedBooks.FindIndex((book) => book.Id == bookId);

                if ((memberIndex != -1) && (bookIndex != -1))
                {
                    Console.WriteLine($"{books[bookIndex].Name} adlı kitap teslim edilecektir. Onaylıyor musunuz ?");
                    Console.WriteLine("(1) Evet \n(2) Hayır");
                    int isReceived = Convert.ToInt32(Console.ReadLine());

                    if (isReceived == 1)
                    {
                        Console.WriteLine($"{books[bookIndex].Name} adlı kitap ödünç verildi.");
                        members[memberIndex].BorrowedBooks.Remove(members[memberIndex].BorrowedBooks[bookIndex]);
                    }
                    else
                        return;
                }
                else
                {
                    Console.WriteLine("Girilen id numaralarına ait kitap veya üye Bulunmuyor. Tekrar denemek ister misiniz ?");
                    Console.WriteLine("(1) Evet \n(2) Hayır");
                    int isRepeat = Convert.ToInt32(Console.ReadLine());

                    if (isRepeat == 1)
                        goto repeat;
                    else return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }

        public void BookTolend()
        {
            try
            {
                repeat:
                Operations.WriteMembers(members);
                Console.Write("Öödünç verilecek üyenin id numarasını girin : ");
                int memberId = Convert.ToInt32(Console.ReadLine().Trim());

                Operations.WriteBooks(books);
                Console.Write("Ödünç verilecek kitabın id numarasını girin : ");
                int bookId = Convert.ToInt32(Console.ReadLine().Trim());

                int memberIndex = members.FindIndex((member) => member.Id == memberId);
                int bookIndex = books.FindIndex((book) => book.Id == bookId);

                if ((memberIndex != -1) && (bookIndex != -1))
                {
                    Console.WriteLine($"{books[bookIndex].Name} adlı kitap ödünç verilecektir. Onaylıyor musunuz ?");
                    Console.WriteLine("(1) Evet \n(2) Hayır");
                    int isLoaned = Convert.ToInt32(Console.ReadLine());

                    if (isLoaned == 1)
                    {
                        Console.WriteLine($"{books[bookIndex].Name} adlı kitap ödünç verildi.");
                        members[memberIndex].BorrowedBooks.Add(books[bookIndex]);
                    }
                    else
                        return;
                }
                else
                {
                    Console.WriteLine("Girilen id numaralarına ait kitap veya üye Bulunmuyor. Tekrar denemek ister misiniz ?");
                    Console.WriteLine("(1) Evet \n(2) Hayır");
                    int isRepeat = Convert.ToInt32(Console.ReadLine());

                    if (isRepeat == 1)
                        goto repeat;
                    else return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
        }

        public void DeleteBook()
        {
            try
            {
                repeat:
                Console.WriteLine("|************************ Kitap Sil *************************|");
                Console.Write("Silmek istediğiniz kitabın adını giriniz : ");
                string bookName = Console.ReadLine().ToLower().Trim();
                bool isFound = false;

                for (int i = 0; i < books.Count; i++)
                {
                    if ((books[i].Name.ToLower().Equals(bookName)))
                    {
                        Console.WriteLine($"{books[i].Name} adlı kitap silinecektir. Onaylıyor musunuz ?");
                        Console.WriteLine("(1) Evet \n(2) Hayır");
                        int isDelete = Convert.ToInt32(Console.ReadLine());

                        if (isDelete == 1)
                        {
                            Console.WriteLine($"{books[i].Name} adlı kitap silindi.");
                            books.RemoveAt(i);
                            isFound = true;
                            break;
                        }
                        else
                            return;
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Aradığınız isimde bir kitap bulunmamaktadır.Tekrar denemek ister misiniz ?");
                    Console.WriteLine("(1) Evet \n(2) Hayır");
                    int isRepeat = Convert.ToInt32(Console.ReadLine());

                    if (isRepeat == 1)
                        goto repeat;
                    else return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : " + ex.Message);
            }
        }
    }

    public struct Operations
    {
        public static void WriteMembers(List<MemberDTO> members)
        {
            foreach (MemberDTO member in members)
            {
                Console.WriteLine("|************************************************************|");
                Console.WriteLine(
                    $"Id: {member.Id}\n" +
                    $"Ad: {member.FirstName}\n" +
                    $"Soyad: {member.LastName}\n" +
                    $"Üyelik Numarası: {member.MembershipNumber}"
                );
                if (member.BorrowedBooks.Count > 0)
                {
                    Console.WriteLine(
                        $"Ödünç Alınan Kitap Sayısı: {member.BorrowedBooks.Count}\n" +
                        $"|**********> Ödünç Alınan Kitaplar"
                    );
                    foreach (BookDTO book in member.BorrowedBooks)
                    {
                        Console.WriteLine($"Kitap Adı : {book.Name}");
                    }
                }
                Console.WriteLine("|************************************************************|");
            }
        }

        public static void WriteBooks(List<BookDTO> books)
        {
            foreach (BookDTO book in books)
            {
                Console.WriteLine("|************************************************************|");
                Console.WriteLine(
                    $"Id: {book.Id}\n" +
                    $"Ad: {book.Name}\n" +
                    $"Yazar: {book.Author}\n" +
                    $"Yayın Yılı: {book.ReleaseYear}"
                );
                Console.WriteLine("|************************************************************|");
            }
        }
    }
}
