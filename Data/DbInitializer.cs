using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zaharia_Alexandru_Lab2.Models;

namespace Zaharia_Alexandru_Lab2.Data {

    public class DbInitializer {

        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any()) {
                return; // BD a fost creata anterior
            }

            var books = new Book[] {
                 new Book {
                     Title = "Baltagul",
                     Author = "Mihail Sadoveanu",
                     Price = Decimal.Parse("22")
                 },
                 new Book {
                     Title = "Enigma Otiliei",
                     Author = "George Calinescu",
                     Price = Decimal.Parse("18")
                 },
                 new Book {
                     Title = "Maytrei",
                     Author = "Mircea Eliade",
                     Price = Decimal.Parse("27")
                 },
                 new Book {
                     Title = "Panza de paianjen",
                     Author = "Cella Serghi",
                     Price = Decimal.Parse("45")
                 },
                 new Book {
                     Title = "Fata de hartie",
                     Author = "Guillame Musso",
                     Price = Decimal.Parse("38")
                 },
                 new Book {
                     Title = "De veghe in lanul de secara",
                     Author="J.D.Salinger",
                     Price = Decimal.Parse("28")
                 },
            };

            foreach (Book book in books)
            {
                context.Books.Add(book);
            }

            context.SaveChanges();

            var customers = new Customer[] {
                new Customer {
                    CustomerID = 1050,
                    Name = "Popescu Marcela",
                    BirthDate = DateTime.Parse("1979-09-01")
                },
                new Customer {
                    CustomerID = 1045,
                    Name = "Mihailescu Cornel",
                    BirthDate = DateTime.Parse("1969-07-08")
                }
            };

            foreach (Customer customer in customers)
            {
                context.Customers.Add(customer);
            }

            context.SaveChanges();

            var publishers = new Publisher[] {
                new Publisher {
                    PublisherName = "Humanitas",
                    Adress = "Str. Aviatorilor, nr. 40, Bucuresti"
                },
                new Publisher {
                    PublisherName = "Nemira",
                    Adress = "Str. Plopilor, nr. 35, Ploiesti"
                },
                new Publisher {
                    PublisherName = "Paralela 45",
                    Adress = "Str. Cascadelor, nr.22, Cluj-Napoca"
                },
            };

            foreach (Publisher publisher in publishers)
            {
                context.Publishers.Add(publisher);
            }

            context.SaveChanges();

            var publishedBooks = new PublishedBook[] {
                new PublishedBook {
                    BookID = books.Single(c => c.Title == "Maytrei" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                },
                new PublishedBook {
                    BookID = books.Single(c => c.Title == "Enigma Otiliei" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Humanitas").ID
                },
                new PublishedBook {
                    BookID = books.Single(c => c.Title == "Baltagul" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Nemira").ID
                },
                new PublishedBook {
                    BookID = books.Single(c => c.Title == "Fata de hartie" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                },
                new PublishedBook {
                    BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                },
                new PublishedBook {
                    BookID = books.Single(c => c.Title == "De veghe in lanul de secara" ).ID,
                    PublisherID = publishers.Single(i => i.PublisherName == "Paralela 45").ID
                },
            };

            foreach (PublishedBook publishedBook in publishedBooks)
            {
                context.PublishedBooks.Add(publishedBook);
            }

            context.SaveChanges();

            var orders = new Order[] {
                new Order {
                    BookID = books.Single(c => c.Title == "Maytrei" ).ID,
                    CustomerID = 1050,
                    OrderDate = DateTime.Parse("2020-02-25")
                },
                new Order {
                    BookID = books.Single(c => c.Title == "Enigma Otiliei").ID,
                    CustomerID = 1045,
                    OrderDate = DateTime.Parse("2020-03-09")
                },
                new Order {
                    BookID = books.Single(c => c.Title == "Baltagul" ).ID,
                    CustomerID = 1045,
                    OrderDate = DateTime.Parse("2020-04-10")
                },
                new Order { 
                    BookID = books.Single(c => c.Title == "Fata de hartie" ).ID,
                    CustomerID = 1050,
                    OrderDate = DateTime.Parse("2020-05-09")
                },
                new Order {
                    BookID = books.Single(c => c.Title == "Panza de paianjen" ).ID,
                    CustomerID = 1050,
                    OrderDate = DateTime.Parse("2020-06-09")
                },
                new Order {
                    BookID = books.Single(c => c.Title == "De veghe in lanul de secara" ).ID,
                    CustomerID = 1050,
                    OrderDate = DateTime.Parse("2020-07-10")
                },
            };

            foreach (Order e in orders) {
                context.Orders.Add(e);
            }

            context.SaveChanges();
        }
    }
}