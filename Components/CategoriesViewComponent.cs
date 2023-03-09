using Microsoft.AspNetCore.Mvc;
using Mission9Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9Assignment.Components
{
    // inherits from base viewcomponent class
    public class CategoriesViewComponent : ViewComponent
    {
        // reference of ibookstorerepository, will be used to filter down book data from db
        private IBookstoreRepository repo { get; set; }

        // sets repo with an instance of ibookstorerepository
        public CategoriesViewComponent (IBookstoreRepository x)
        {
            repo = x;
        }

        // gets and returns all categories to the ui
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];
            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
