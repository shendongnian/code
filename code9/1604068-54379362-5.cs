    // Partial JSON document (originates from controller).
    JObject newData = new { role = 9001 };
    
    // Current entity from EF persistence medium.
    User user = context.Users.FindAsync(id);
     
    // Output:
    //
    //     Username : engineer-186f
    //     Role     : 1
    //
    Debug.WriteLine($"Username : {0}", user.Username);
    Debug.WriteLine($"Role     : {0}", user.Role);
    
    // Partially updated entity.
    User updatedUser = AtomicModifier.Patch<User>(user, newData);
    
    // Output:
    //
    //     Username : engineer-186f
    //     Role     : 9001
    //
    Debug.WriteLine($"Username : {0}", user.Username);
    Debug.WriteLine($"Role     : {0}", user.Role);
    
    // Setting the new values to the context.
    context.Entry(user).CurrentValues.SetValues(updatedUser);
