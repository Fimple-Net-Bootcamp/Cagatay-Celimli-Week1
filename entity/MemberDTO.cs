using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libraryManagementSystem.entity
{
    public class MemberDTO
    {
        private static int lastMemberId = 0;
        private int id;
        private string firstName;
        private string lastName;
        private int membershipNumber;
        private List<BookDTO> borrowedBooks;

        public MemberDTO(string _firstName, string _lastName, int _membershipNumber)
        {
            this.id = ++lastMemberId;
            this.firstName = _firstName;
            this.lastName = _lastName;
            this.membershipNumber = _membershipNumber;
            this.borrowedBooks = new List<BookDTO>();
        }

        public static int LastId { set => lastMemberId = value; }
        public int Id { get => id; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int MembershipNumber { get => membershipNumber; set => membershipNumber = value; }
        public List<BookDTO> BorrowedBooks { get => borrowedBooks; set => borrowedBooks = value; }
    }
}
