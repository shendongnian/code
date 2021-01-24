    // Partial JSON document (originates from controller).
    JObject newData = new { role = 2 };
    
    // Current entity from EF persistence medium.
    User user = context.Users.FindAsync(id);
    
    // Output -> "Role: 1"
    Debug.WriteLine($"Role: {0}", user.Role);
    
    // Partially updated entity.
    User updatedUser = AtomicModifier.Patch<User>(user, newData);
    
    // Output -> "Role: 2"
    Debug.WriteLine($"Role: {0}", user.Role);
    
    // Setting the new values to the context.
    context.Entry(user).CurrentValues.SetValues(updatedUser);
