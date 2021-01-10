using BooksCatalog.Common;
using BooksCatalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCatalog.Business
{
    public class BookManager : IBookManager
    {
        IBookRepository repo = new BookRepository();

        public void AddBook(Book addBook)
        {
            repo.AddBook(addBook);
        }

        public void AddIssuedBook(int id)
        {
            var addIssuedBook = new IssueBook
            {
                BookID = id,
                DateOfIssue = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(10),
                MembershipName = "Student"
            };

            repo.AddIssuedBook(addIssuedBook);
        }

        public void AddReturnedBook(int issueId)
        {
            var issuedBookReturn = new ReturnBook
            {
                IssueID = issueId,
                DateOfReturn = DateTime.Now
            };

            repo.AddReturnedBook(issuedBookReturn);
        }

        public void DeleteBook(int id)
        {
            repo.DeleteBook(id);
        }

        public void DeleteIssuedBook(int id)
        {
            repo.DeleteIssuedBook(id);
        }

        public void DeleteReturnedBook(int id)
        {
            repo.DeleteReturnedBook(id);
        }

        public void EditBook(Book updateBook)
        {
            repo.EditBook(updateBook);
        }

        public void EditIssuedBook(IssueBook editIssuedBook)
        {
            repo.EditIssuedBook(editIssuedBook);
        }

        public void EditReturnedBook(ReturnBook editReturnedBook)
        {
            repo.EditReturnedBook(editReturnedBook);
        }

        public List<Book> GetAllBooks()
        {
            return repo.GetAllBooks();
        }

        public List<IssueBook> GetAllIssuedBooks()
        {
            return repo.GetAllIssuedBooks();
        }

        public List<ReturnBook> GetAllReturnedBooks()
        {
            return repo.GetAllReturnedBooks();
        }

        public Book GetBookById(int id)
        {
            return repo.GetBookById(id);
        }

        public IssueBook GetIssuedBookById(int id)
        {
            return repo.GetIssuedBookById(id);
        }

        public ReturnBook GetReturnedBookById(int id)
        {
            return repo.GetReturnedBookById(id);
        }

        public List<Book> SearchByBookNameOrAuthor(string book)
        {
            return repo.SearchByBookNameOrAuthor(book);
        }

        public List<ReturnBook> SearchByDateOfReturn(string returnedBook)
        {
            return repo.SearchByDateOfReturn(returnedBook);
        }

        public List<IssueBook> SearchByMembershipNameOrDOI(string issuedBook)
        {
            return repo.SearchByMembershipNameOrDOI(issuedBook);
        }
    }
}
