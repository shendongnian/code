    usersTemp.ToList().ForEach(u => {
        var user = Users.FirstOrDefault(x => x.ID == u.ID);
        if (user != null) {//User already exists
            var index = Users.IndexOf(user);//get its location in list
            Users[index] = u;//replace it with new object
        } else {
            Users.Add(u);
        }
    });
