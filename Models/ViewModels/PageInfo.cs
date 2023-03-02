using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Assignment.Models.ViewModels
{
    public class PageInfo
    {
        // store total number of books
        public int TotalNumBooks { get; set; }
        // store desired books per page
        public int BooksPerPage { get; set; }
        // store session current page
        public int CurrentPage { get; set; }
        // calculate total number of pages
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
    }
}
