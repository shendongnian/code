    public class LoginModel : PageModel
    {
        private IFileSystem fileSystem;
        public LoginModel(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }
        [BindProperty]
        public string EmailAddress { get; set; }
        public async Task<IActionResult> OnPostRefresh()
        {
           // now you can use this.fileSystem
           //to do : return something
        }
    }
