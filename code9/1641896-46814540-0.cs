    @pages "{ownerId}" // note this part! very important!
    @using Microsoft.AspNetCore.Mvc.RazorPages
    @model ProductsModel
    @functions {
        public class ProductsModel : PageModel
        {
            public void OnGet(string ownerId) // pass the string
            {
                // your code here
            }
        }
    }
    <div>...</div>
