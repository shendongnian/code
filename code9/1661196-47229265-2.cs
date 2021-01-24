    foreach(var item in user)
    {
      if(item.username.Equals(username_input)
        && user_input.Equals(item.password))
      {
        Console.WriteLine("Login successful");
        break; // no need to check more.. or is there?
      }               
    }
