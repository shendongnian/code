    string input = "FirstName=Alpha&LastName=Beta&Email=blah@blah.com&Country=UnitedStates&Email=foo@foobar.com";
    Dictionary<string,string> emails = input.Split(new char[] { '&' }).Where(param => param.ToLower().Contains("email")).Select(param => param.Split(new char[] { '=' })).ToDictionary(x=> x[1], x=> x[0]);
    foreach (string email in emails.Keys)
    {
        Console.WriteLine(email);
    }
