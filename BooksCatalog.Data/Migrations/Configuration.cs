namespace BooksCatalog.Data.Migrations
{
    using BooksCatalog.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BooksCatalog.Data.BooksCatalogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BooksCatalog.Data.BooksCatalogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var books = new List<Book>();
            for(int i=0; i<10; i++)
            {
                var book = new Book
                {
                    BookName = $"Name {i+1}",
                    ISBN = (i+1).ToString(),
                    Author = $"Author {i%3}",
                    Price = 100+i
                };

                books.Add(book);
            }

            foreach (var book in books)
            {
                context.Books.AddOrUpdate(book);
            }
            
            context.SaveChanges();
        }
    }
}
