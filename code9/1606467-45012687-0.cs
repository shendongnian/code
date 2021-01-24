    private void ReplaceUserInHierarchy(User modifiedUser, List<User> users)
    {
        foreach (var user in users)
        {
            if (user.Id == modifiedUser.Id)
            {
                user.FirstName = modifiedUser.FirstName; // etc  
                continue; // go to next user instead of return            
            }
            
            // assume user cannot be in own employees hierarchy
            ReplaceUserInHierarchy(modifiedUser, user.Employees);
        }
    }
