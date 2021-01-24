    public class SomeModel: PageModel
        {
            [BindProperty]
            public SomeViewModel Input { get; set; }
    
            public async Task OnGetAsync()
            {
    
            }
    
            public async Task<IActionResult> OnPostAsync()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                
                // This won't be null.
                var showMeSomething = Input.SingleInput;
                return RedirectToPage();
            }
        }
