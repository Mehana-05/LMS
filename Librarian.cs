using System;

namespace LMS
{
    internal class Librarian : Person
    {
        public int EmployeeID { get; set; }

        public Librarian(int employeeID, string name) : base(name)
        {
            EmployeeID = employeeID;
        }

        public void AddBook(Library library, Book book)
        {
            library.Books.Add(book);
        }

        public void RemoveBook(Library library, Book book)
        {
            library.Books.Remove(book);
        }

        public void DisplayAllBooks(Library library)
        {
            foreach (var book in library.Books)
            {
                Console.WriteLine($"ID:{book.BookID}, Title: {book.Title}, Author: {book.Author}, Copies: {book.NumberOfCopies}");
            }
        }

        public void RegisterMember(Library library, Member member)
        {
            library.Members.Add(member);
        }

        public void DisplayAllMembers(Library library)
        {
            foreach (var member in library.Members)
            {
                Console.WriteLine($"MemberID: {member.MemberID}, Name: {member.Name}");
            }
        }
    }

}
