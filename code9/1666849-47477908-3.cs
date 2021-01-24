    public class CreateModel : PageModel
    {
         private readonly IHostingEnvironment hostingEnvironment;
         public CreateModel(IHostingEnvironment environment)
         {
            hostingEnvironment = environment;
         }
        //Your existing code for properties goes here
        public async Task<IActionResult> OnPostAsync()
        {
            var m=new Movie { Title = this.Title, Price= this.Price };
            if (this.Image != null)
            {
                var fileName = GetUniqueName(this.Image.FileName); 
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                var filePath = Path.Combine(uploads,fileName);
                this.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                m.ImageName = fileName; // Set the file name
            }
            _context.Movie.Add(m);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + Guid.NewGuid().ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }
    }
