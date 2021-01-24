    public static async Task<MyUser> FindByUserAsync(
        this UserManager<MyUser> input,
        ClaimsPrincipal user )
    {
        return await input.Users
		    .Include(x => x.InverseNavigationTable)
			.SingleOrDefaultAsync(x => x.NormalizedUserName == user.Identity.Name.ToUpper());
    }
