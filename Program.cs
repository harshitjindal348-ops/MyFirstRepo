using System;
using System.Collections.Generic;
//  BOOK CLASS 
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsIssued { get; set; }

    public Book(string title, string author)
    {
        Title = title;
        Author = author;
        IsIssued = false;
    }

    public void Print()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Issued: {IsIssued}");
    }
}

//  MEMBER CLASS 
public class Member
{
    public string Name { get; set; }

    public Member(string name)
    {
        Name = name;
    }
}

//  LIBRARY CLASS 
public class Library
{
    private List<Book> books = new List<Book>();

    // Add book
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added!");
    }

    // Show all books
    public void ShowBooks()
    {
        Console.WriteLine("\n--- Book List ---");
        foreach (Book b in books)
        {
            b.Print();
        }
    }

    // Issue book
    public void IssueBook(string title)
    {
        foreach (Book b in books)
        {
            if (b.Title == title && !b.IsIssued)
            {
                b.IsIssued = true;
                Console.WriteLine("Book issued!");
                return;
            }
        }
        Console.WriteLine("Book not available!");
    }

    // Return book
    public void ReturnBook(string title)
    {
        foreach (Book b in books)
        {
            if (b.Title == title && b.IsIssued)
            {
                b.IsIssued = false;
                Console.WriteLine("Book returned!");
                return;
            }
        }
        Console.WriteLine("Invalid return!");
    }
}

//  MAIN PROGRAM 
class Program
{
    static void Main()
    {
        Library lib = new Library();

        while (true)
        {
            Console.WriteLine("\n--- LIBRARY MENU ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Show Books");
            Console.WriteLine("3. Issue Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("0. Exit");

            Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter title: ");
                    string title = Console.ReadLine();

                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();

                    lib.AddBook(new Book(title, author));
                    break;

                case 2:
                    lib.ShowBooks();
                    break;

                case 3:
                    Console.Write("Enter book title: ");
                    lib.IssueBook(Console.ReadLine());
                    break;

                case 4:
                    Console.Write("Enter book title: ");
                    lib.ReturnBook(Console.ReadLine());
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}