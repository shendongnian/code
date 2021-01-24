    using System;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    namespace CoreRazor2.Pages
    {
        public class IndexModel : PageModel
        {
            public int Result { get; set; }
            public void OnGet(string operationType, int first, int second)
            {
                switch (operationType)
                {
                    case "+":
                        Result = first + second;
                        break;
                    case "-":
                        Result = first - second;
                        break;
                    case "/":
                        Result = first / second;
                        break;
                    case "*":
                        Result = first * second;
                        break;
                }
            }
        }
    }
