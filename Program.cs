using System;

namespace LMS
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library();
            Librarian librarian = new Librarian(1, "Ahmed Mohammed");
            BorrowingSystem borrowingSystem = new BorrowingSystem();

            Book book1 = new Book(1, "Torab Almas", "Ahmed Mourad", 3);
            Book book2 = new Book(2, "The Subtle Art of Not Giving a F*ck", "Mark Manson", 5);

            librarian.AddBook(library, book1);
            librarian.AddBook(library, book2);

            Member member1 = new Member(101, "Kevin Hart");
            Member member2 = new Member(102, "Dwayne Johnson");

            librarian.RegisterMember(library, member1);
            librarian.RegisterMember(library, member2);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                DisplayMenu(librarian);
                exit = HandleUserChoice(library, librarian, borrowingSystem);
            }
        }

        private static void DisplayMenu(Librarian librarian)
        {
            Console.WriteLine("Library Management System - {0} - {1}", DateTime.Now, librarian.Name);
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Display all members");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }

        private static bool HandleUserChoice(Library library, Librarian librarian, BorrowingSystem borrowingSystem)
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    librarian.DisplayAllBooks(library);
                    break;
                case "2":
                    librarian.DisplayAllMembers(library);
                    break;
                case "3":
                    BorrowBook(library, borrowingSystem);
                    break;
                case "4":
                    ReturnBook(library, borrowingSystem);
                    break;
                case "5":
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return false;
        }

        private static void BorrowBook(Library library, BorrowingSystem borrowingSystem)
        {
            Console.Write("Enter member ID: ");
            int memberId = int.Parse(Console.ReadLine());
            Member member = library.GetMemberById(memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.Write("Enter book ID: ");
            int bookId = int.Parse(Console.ReadLine());
            Book book = library.GetBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            borrowingSystem.BorrowBook(member, book);
        }

        private static void ReturnBook(Library library, BorrowingSystem borrowingSystem)
        {
            Console.Write("Enter member ID: ");
            int memberId = int.Parse(Console.ReadLine());
            Member member = library.GetMemberById(memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            Console.Write("Enter book ID: ");
            int bookId = int.Parse(Console.ReadLine());
            Book book = library.GetBookById(bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!borrowingSystem.IsBookBorrowedByMember(member, book))
            {
                Console.WriteLine("This book is not borrowed by the member.");
                return;
            }

            borrowingSystem.ReturnBook(member, book);
        }
    }
}