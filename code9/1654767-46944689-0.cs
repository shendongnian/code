    User authenticatedUser = HttpContext.Items.TryGetValue("authenticatedUser" ...)   
    if(authenticatedUser != null)
    {
        _usersRepository.Attach(authenticatedUser);  
        authenticatedUser.Username = "John Doe";  
        _usersRepository.SaveChanges(); 
    }
 
