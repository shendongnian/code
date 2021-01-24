	public SignUpMeta GetSignUpMeta(User user)
	{
		return new SignUpMeta()
		{
			IsDuplicateEmail = User.Where(u => u.Email == user.Email).Take(1).Any(),
			IsDuplicateUserName = User.Where(u => u.UserName == user.UserName).Take(1).Any(),
		};
	}
