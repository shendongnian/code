    var email = emailEntry.Text;
    var emailQuery = await MobileService.GetTable<Users>()
                                        .Where(item => item.Email == email)
                                        .ToEnumerableAsync();
    var user = emailQuery.FirstOrDefault();
    if(user != null) {
        var id = user.Id;
    }
