    {
			if (editUserModel.UserName == null)
			{
				editUserModel.UserName = editUserModel.Email;
			}
			if (ModelState.IsValid)
			{
				db.Entry(editUserModel).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("UsersList");
			}
			return View(editUserModel);
    }
