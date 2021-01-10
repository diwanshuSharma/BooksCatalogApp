//using DataAnnotationsExtensions;
using FormFactory.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCatalog.Web.Models
{
    public class HUser
    {
        [Email]
        public string Email { get; set; }
        [Password]
        public string Password { get; set; }
    }
}