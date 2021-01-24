    public async Task<IActionResult> Roles(string id)
    {
        if (id.Length > 0 && id[0] == '{')
           id = id.Substring(1, id.Length - 2);
        var user = await this.userManager.FindByIdAsync(id);
        var u = this.userManager.GetUserId(User);
        if (user == null)
        {
            return NotFound();
        }      
     ....
