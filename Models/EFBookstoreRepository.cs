using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Assignment.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext bookstoreContext { get; set; }

        public EFBookstoreRepository (BookstoreContext context)
        {
            bookstoreContext = context;
        }
        public IQueryable<Books> Books => bookstoreContext.Books;
    }
}
