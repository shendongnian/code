    var email = emailEntry.Text;
    var query = await MobileService.GetTable<Users>()
                                   .Where(item => item.Email == email)
                                   .ToEnumerableAsync();
    var emailIsValid = query.Any();
