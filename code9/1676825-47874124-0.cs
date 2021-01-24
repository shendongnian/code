	private readonly IUserService userService;
	public UserController(IUserService userService){
	  this.userService = userService;
	}
	public async Task<IHttpActionResult> GetUserById(Guid id)
	{
		try
		{
			return Ok(await userService.GetByIdAsync(id));
		}
		catch(Exception ex)
		{
			return InternalServerError(ex);
		}
	}
