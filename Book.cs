namespace LMS
{
    internal class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int NumberOfCopies { get; set; }

        public Book(int bookId, string title, string author, int numberOfCopies)
        {
            BookID = bookId;
            Title = title;
            Author = author;
            NumberOfCopies = numberOfCopies;
        }
    }
}