using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksCatalog.Common
{
    public class ReturnBook
    {
        [Key]
        public int ReturnID { get; set; }
        public int IssueID { get; set; }
        public IssueBook IssueBook { get; set; }
        public DateTime DateOfReturn { get; set; }
    }
}
