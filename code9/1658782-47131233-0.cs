    public class Schema
    {
        [Required]
        [BindRequired]
        public string Id { get; set; }
    }
    public class TestModel : PageModel
    {
        [BindProperty]
        public Schema Schema { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            // SchemaId is NULL right here!
            if (!ModelState.IsValid) // Yet IsValid = true!
            {
                return Page();
            }
            return Page();
        }
    }
