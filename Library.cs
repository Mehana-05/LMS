using System.Collections.Generic;
using System.Linq;

namespace LMS
{
    internal class Library
    {
        public List<Book> Books { get; set; }
        public List<Member> Members { get; set; }

        public Library()
        {
            Books = new List<Book>();
            Members = new List<Member>();
        }

        public Member GetMemberById(int memberId)
        {
            return Members.FirstOrDefault(member => member.MemberID == memberId);
        }

        public Book GetBookById(int bookId)
        {
            return Books.FirstOrDefault(book => book.BookID == bookId);
        }
    }
}