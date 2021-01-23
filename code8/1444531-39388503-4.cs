    public List<RoleDTO> GetRoleByType(Guid roleTypeId)
    {
      var roleDTOs = (from r in ctx.Roles
      join rc in ctx.RoleClaims on r.RoleID equals rc.RoleID
      where r.RoleTypeID == roleTypeId
      select new RoleDTO
      {
          RoleId = r.RoleID,
          EnglishName = r.EnglishName,
          TypeId = r.TypeID,
          claims = ctx.Actions.Where( c => c.ActionId == rc.ActionId).Select( s => new ClaimDTO
		  {
		    ActionID = s.ActionID,
			ActionCode = s.ActionCode,
			ActionLevel = s.ActionLevel,
			GrantDate = s.GrantDate
			
		  })ToList()
      }).ToList();
    return roleDTOs;
    }
