	public ActionResult MyProfile(ProfileViewModel m, HttpPostedFileBase profilePicture)
	{
		 User currentUser = UserRep.GetCurrentUser(User.Identity.GetUserId());
		 currentUser = Mapper.Map<ProfileViewModel, User>(currentUser, m); // you can skip assign to variable
		 ...
	}
	
