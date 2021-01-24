    public class CreateModel : PageModel
    {
         private readonly YourDbContext context;
         private readonly IHostingEnvironment hostingEnvironment;
         public CreateModel(YourDbContext context,IHostingEnvironment environment)
         {
            this.hostingEnvironment = environment;
            this.context=context;
         }
        //Your existing code for properties goes here
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            if (this.Image != null)
            {
                var fileName = GetUniqueName(this.Image.FileName); 
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads,fileName);
                this.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                this.Movie.ImageName = fileName; // Set the file name
            }
            context.Movie.Add(this.Movie);
            await context.SaveChangesAsync();
            return RedirectToPage("MovieList");
        }
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
    }
