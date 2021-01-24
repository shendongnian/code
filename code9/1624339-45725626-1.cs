    var result = await this.UserManager.CreateAsync(user, password);
    if (result.Succeeded) {
        await this.UserManager.AddToRoleAsync(user.Id, MyApp.IsMember);
    } else {
        var errors = result.Errors;
        var message = string.Join(", ", errors);
        ModelState.Add("", message);
    }
