    public class CreateModel : PageModel
    {
        [BindProperty]
        public string Title { get; set; }
        [BindProperty]
        public decimal Price { get; set; }
        [BindProperty]
        public IFormFile Image { set; get; }
    }
