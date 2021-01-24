    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        //Override values for created by and date
        Blog.CreatedDate = DateTime.Now;
        Blog.CreatedBy = User.Identity.Name.ToString();
        _context.Blogs.Add(Blog);
        await _context.SaveChangesAsync();
        return RedirectToPage("./Index");
    }
