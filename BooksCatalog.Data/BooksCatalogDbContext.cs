using BooksCatalog.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Data
{
    class BooksCatalogDbContext : DbContext
    {
        public IDbSet<Book> Books { get; set; }
        public IDbSet<IssueBook> IssueBooks { get; set; }
        public IDbSet<ReturnBook> ReturnBooks { get; set; }
    }
}
