using System;
using System.Collections.Generic;

class LibraryManager
{
    static void Main()
    {
        List<string> books = new List<string> { "Book A", "Book B", "Book C", "Book D", "Book E" };
        List<string> borrowedBooks = new List<string>();
        const int maxBorrowLimit = 3;

        while (true)
        {
            Console.WriteLine("\nLibrary Management System");
            Console.WriteLine("Choose an option: add, remove, search, borrow, return, exit");
            string action = Console.ReadLine()?.Trim().ToLower();

            switch (action)
            {
                case "add":
                    AddBook(books);
                    break;

                case "remove":
                    RemoveBook(books);
                    break;

                case "search":
                    SearchBook(books);
                    break;

                case "borrow":
                    BorrowBook(books, borrowedBooks, maxBorrowLimit);
                    break;

                case "return":
                    ReturnBook(books, borrowedBooks);
                    break;

                case "exit":
                    Console.WriteLine("Exiting the Library Management System. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid action. Please choose a valid option.");
                    break;
            }

            DisplayBooks("Available books", books);
            DisplayBooks("Borrowed books", borrowedBooks);
        }
    }

    static void AddBook(List<string> books)
    {
        Console.WriteLine("Enter the title of the book to add:");
        string newBook = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(newBook))
        {
            Console.WriteLine("Book title cannot be empty.");
        }
        else if (books.Contains(newBook, StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("This book is already in the library.");
        }
        else
        {
            books.Add(newBook);
            Console.WriteLine($"'{newBook}' has been added to the library.");
        }
    }

    static void RemoveBook(List<string> books)
    {
        Console.WriteLine("Enter the title of the book to remove:");
        string removeBook = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(removeBook))
        {
            Console.WriteLine("Book title cannot be empty.");
        }
        else
        {
            int index = books.FindIndex(b => b.Equals(removeBook, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                books.RemoveAt(index);
                Console.WriteLine($"'{removeBook}' has been removed from the library.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }

    static void SearchBook(List<string> books)
    {
        Console.WriteLine("Enter the title of the book to search for:");
        string searchBook = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(searchBook))
        {
            Console.WriteLine("Book title cannot be empty.");
        }
        else
        {
            bool found = books.Exists(b => b.Equals(searchBook, StringComparison.OrdinalIgnoreCase));
            if (found)
            {
                Console.WriteLine($"'{searchBook}' is available in the library.");
            }
            else
            {
                Console.WriteLine($"'{searchBook}' is not in the library.");
            }
        }
    }

    static void BorrowBook(List<string> books, List<string> borrowedBooks, int maxBorrowLimit)
    {
        if (borrowedBooks.Count >= maxBorrowLimit)
        {
            Console.WriteLine($"You have reached the borrowing limit of {maxBorrowLimit} books.");
            return;
        }

        Console.WriteLine("Enter the title of the book to borrow:");
        string borrowBook = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(borrowBook))
        {
            Console.WriteLine("Book title cannot be empty.");
        }
        else
        {
            int index = books.FindIndex(b => b.Equals(borrowBook, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                borrowedBooks.Add(books[index]); // Add the book to the borrowedBooks list
                books.RemoveAt(index);          // Remove the book from the available books list
                Console.WriteLine($"You have borrowed '{borrowBook}'.");
            }
            else
            {
                Console.WriteLine($"'{borrowBook}' is not available in the library.");
            }
        }
    }

    static void ReturnBook(List<string> books, List<string> borrowedBooks)
    {
        Console.WriteLine("Enter the title of the book to return:");
        string returnBook = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(returnBook))
        {
            Console.WriteLine("Book title cannot be empty.");
        }
        else
        {
            int index = borrowedBooks.FindIndex(b => b.Equals(returnBook, StringComparison.OrdinalIgnoreCase));
            if (index >= 0)
            {
                books.Add(borrowedBooks[index]); // Add the book back to the available books list
                borrowedBooks.RemoveAt(index);  // Remove the book from the borrowedBooks list
                Console.WriteLine($"'{returnBook}' has been returned.");
            }
            else
            {
                Console.WriteLine($"'{returnBook}' is not currently borrowed.");
            }
        }
    }

    static void DisplayBooks(string title, List<string> books)
    {
        Console.WriteLine($"\n{title}:");
        if (books.Count == 0)
        {
            Console.WriteLine("None");
        }
        else
        {
            foreach (string book in books)
            {
                Console.WriteLine(book);
            }
        }
    }
}