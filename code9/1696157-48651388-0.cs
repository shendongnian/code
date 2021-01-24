    [HttpPost]
    public async Task<ActionResult> GetUser(UserDetailsViewModels m, int id)
    {
        var dtsource = await RequestManager.DoGet<User>("User/" + id); //Call the API
    
        m.Email = dtsource.Email;
        m.Note = dtsource.Note;
        m.Username = dtsource.Username;
        return PartialView("Partial/_User", m);
    }
