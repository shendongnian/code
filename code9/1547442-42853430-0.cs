     var userRoles = unitOfWork.UserRoles.GetByUserId(userId).ToList();
                // Delete user role
                unitOfWork.UserRoles.RemoveRange(userRoles);
    
                // Perform changes
                unitOfWork.SaveChanges();
