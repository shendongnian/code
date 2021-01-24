    using (TransactionScope scope = new TransactionScope())
    {
        userManager.RemoveFromRoles(user.Id, GetAllUserRoles());
        //add the next save changes as remove then adding using identity need separate state management
        db.SaveChanges();
        userManager.AddToRoles(user.Id, userRoles);
        db.Entry(user).State = EntityState.Modified;
        db.SaveChanges();
        scope.Complete();
    }
    return RedirectToAction("UsersList");
