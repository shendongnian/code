    List<Users> mylist = SelectedList
        .Where(item => (int)((object[])item)[0] == 1)
        .Select(item =>
        {
            var values = (object[])item;
            return new Users()
            {
                UserId = (int)values[0],
                Name = (string)values[1],
                Address = (string)values[2]
            };
        })
        .ToList();
