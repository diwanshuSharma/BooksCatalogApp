using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Common
{
    public class IssueBook
    {
        [Key]
        public int IssueID { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public string MembershipName { get; set; }
    }
}
