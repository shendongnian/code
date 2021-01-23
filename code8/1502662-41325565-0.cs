    [HttpDelete]
    public async Task Delete(string id) {
        var user = _userManager.Users.Where(a => a.Id == id).FirstOrDefault();
        user.Deleted = true;
        var result= await _userManager.UpdateAsync(user);
    }
