using System;
using System.Collections.Generic;

namespace LMS
{
  internal class BorrowingSystem
    {
        private Dictionary<int, List<int>> borrowedBooks = new Dictionary<int, List<int>>();

        public void BorrowBook(Member member, Book book)
        {
            if (!borrowedBooks.ContainsKey(member.MemberID))
            {
                borrowedBooks[member.MemberID] = new List<int>();
            }

            if (book.NumberOfCopies > 0)
            {
                borrowedBooks[member.MemberID].Add(book.BookID);
                book.NumberOfCopies--;
                Console.WriteLine($"{member.Name} borrowed {book.Title}");
            }
            else
            {
                Console.WriteLine("No copies available.");
            }
        }

        public void ReturnBook(Member member, Book book)
        {
            if (borrowedBooks.ContainsKey(member.MemberID) && borrowedBooks[member.MemberID].Contains(book.BookID))
            {
                borrowedBooks[member.MemberID].Remove(book.BookID);
                book.NumberOfCopies++;
                Console.WriteLine($"{member.Name} returned {book.Title}");
            }
        }

        public bool IsBookBorrowedByMember(Member member, Book book)
        {
            return borrowedBooks.ContainsKey(member.MemberID) && borrowedBooks[member.MemberID].Contains(book.BookID);
        }
    }
}
