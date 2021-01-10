using BooksCatalog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Data
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        List<IssueBook> GetAllIssuedBooks();
        List<ReturnBook> GetAllReturnedBooks();

        Book GetBookById(int id);
        IssueBook GetIssuedBookById(int id);
        ReturnBook GetReturnedBookById(int id);


        void AddBook(Book addBook);
        void DeleteBook(int id);
        void EditBook(Book UpdateBook);

        void AddIssuedBook(IssueBook addIssueBook);
        void DeleteIssuedBook(int id);
        void EditIssuedBook(IssueBook editIssuedBook);

        void AddReturnedBook(ReturnBook addReturnedBook);
        void DeleteReturnedBook(int id);
        void EditReturnedBook(ReturnBook editReturnedBook);

        List<Book> SearchByBookNameOrAuthor(string book);
        List<IssueBook> SearchByMembershipNameOrDOI(string issuedBook);
        List<ReturnBook> SearchByDateOfReturn(string returnedBook);
    }
}
