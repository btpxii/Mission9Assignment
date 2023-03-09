using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission9Assignment.Models;
using Mission9Assignment.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Assignment.Controllers
{
    // inherits from base controller class
    public class HomeController : Controller
    {
        //stores reference to ibookstorerepository, will be used to access stored book data from db
        private IBookstoreRepository repo;

        // sets above reference to an instance of ibookstorerepository
        public HomeController (IBookstoreRepository x)
        {
            repo = x;
        }

        // handles pagination, categorization by breaking up and filtering data based on parameters passed in
        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var books = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookCategory == null
                                        ? repo.Books.Count() 
                                        : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(books);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
