    public async Task<Client> AuthenticateAsync(string apiKey, string password) {
        var entity = await _context.tbl_Client.FirstOrDefaultAsync(
            c => c.ApiKey == apiKey && c.Password == password
        );
        var model = entity.ToModel();// <-- extension method used here
        return model;
    }
