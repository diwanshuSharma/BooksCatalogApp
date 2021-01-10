using BooksCatalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Data
{
    public class BookRepository : IBookRepository
    {
        BooksCatalogDbContext db = new BooksCatalogDbContext();

        public void AddBook(Book addBook)
        {
            db.Books.Add(addBook);
            db.SaveChanges();
        }

        public void AddIssuedBook(IssueBook addIssueBook)
        {
            db.IssueBooks.Add(addIssueBook);
            db.SaveChanges();
        }

        public void AddReturnedBook(ReturnBook addReturnedBook)
        {
            db.ReturnBooks.Add(addReturnedBook);
            db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            db.Entry<Book>(db.Books.Find(id)).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public void DeleteIssuedBook(int id)
        {
            db.Entry<IssueBook>(db.IssueBooks.Find(id)).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public void DeleteReturnedBook(int id)
        {
            db.Entry<ReturnBook>(db.ReturnBooks.Find(id)).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
        }

        public void EditBook(Book updateBook)
        {
            db.Entry<Book>(updateBook).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void EditIssuedBook(IssueBook editIssuedBook)
        {
            db.Entry<IssueBook>(editIssuedBook).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void EditReturnedBook(ReturnBook editReturnedBook)
        {
            db.Entry<ReturnBook>(editReturnedBook).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public List<IssueBook> GetAllIssuedBooks()
        {
            return db.IssueBooks.ToList();
        }

        public List<ReturnBook> GetAllReturnedBooks()
        {
            return db.ReturnBooks.ToList();
        }

        public Book GetBookById(int id)
        {
            var book = db.Books.Find(id);
            return book;
        }

        public IssueBook GetIssuedBookById(int id)
        {
            var issuedBook = db.IssueBooks.Find(id);
            return issuedBook;
        }

        public ReturnBook GetReturnedBookById(int id)
        {
            var returnedBook = db.ReturnBooks.Find(id);
            return returnedBook;
        }

        public List<Book> SearchByBookNameOrAuthor(string book)
        {
            var searchedBooks = (from b in db.Books
            where b.BookName.Contains(book) || b.Author.Contains(book)
            select b).ToList();

            return searchedBooks;
        }

        public List<ReturnBook> SearchByDateOfReturn(string returnedBook)
        {
            var searchedReturnedBook = (from rb in db.ReturnBooks
                                        where rb.DateOfReturn.ToString().Contains(returnedBook)
                                        select rb).ToList();

            return searchedReturnedBook;
        }

        public List<IssueBook> SearchByMembershipNameOrDOI(string issuedBook)
        {
            var searchIssuedBooks = (from ib in db.IssueBooks
                                     where ib.MembershipName.Contains(issuedBook) || ib.DateOfIssue.ToString().Contains(issuedBook)
                                     select ib).ToList();

            return searchIssuedBooks;
        }
    }
}
