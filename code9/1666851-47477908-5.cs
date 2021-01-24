    public class CreateModel : PageModel
    {
        [BindProperty]
        public Movie Movie { set; get; }
        [BindProperty]
        public IFormFile Image { set; get; }
    }
