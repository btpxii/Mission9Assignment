using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission9Assignment.Infrastructure;
using Mission9Assignment.Models;

namespace Mission9Assignment.Pages
{
    public class AddModel : PageModel
    {
        // creates an instance of ibookstorerepository, used to access stored data on books from db
        private IBookstoreRepository repo { get; set; }

        // sets the above reference equal to an instance of ibookstorerepository
        public AddModel (IBookstoreRepository x)
        {
            repo = x;
        }

        public Cart cart { get; set; }

        public string ReturnUrl { get; set; }

        // used to get cart data from the session, store return url for continue button
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        // used to add items to the cart session variable when add button is clicked
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl});
        }
    }
}
