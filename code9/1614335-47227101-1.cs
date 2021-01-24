	public List<TblUser> GetUserListWithRoles()
	{
	    GenericRepository<TblUser> repository = new GenericRepository<TblUser>(_context);
	    List<TblUser> userList = new List<TblUser>();
	    string[] includes = { "TblUserRol", "TblUserRol.FkIdRolNavigation" };
	    userList = repository.GetWithInclude(c => c.State == true, includes).ToList();
	    return userList;
	}
