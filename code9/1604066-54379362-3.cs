    // Partial JSON document (originates from controller).
    JObject newData = new { role = 2 };
    
    // Current entity from EF persistence medium.
    User user = context.Users.FindAsync(id);
     
    // Output:
    //
    //     Username : user1
    //     Role     : 1
    //
    Debug.WriteLine($"Username : {0}", user.Username);
    Debug.WriteLine($"Role     : {0}", user.Role);
    
    // Partially updated entity.
    User updatedUser = AtomicModifier.Patch<User>(user, newData);
    
    // Output:
    //
    //     Username : user1
    //     Role     : 2
    //
    Debug.WriteLine($"Username : {0}", user.Username);
    Debug.WriteLine($"Role     : {0}", user.Role);
    
    // Setting the new values to the context.
    context.Entry(user).CurrentValues.SetValues(updatedUser);
