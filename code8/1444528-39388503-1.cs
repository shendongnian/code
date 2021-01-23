    public List<RoleDTO> GetRoleByType(Guid roleTypeId)
    {
    var roleDTOs = (from r in ctx.Roles
          join rc in ctx.RoleClaims on r.RoleID equals rc.RoleID
          join a in ctx.Actions on rc.ActionID equals a.ActionID
          where r.RoleTypeID == roleTypeId
          select new RoleDTO
          {
              RoleId = r.RoleID,
              EnglishName = r.EnglishName,
              TypeId = r.TypeID,
              claims = r.Claims.Where( c => c.ActionId == rc.ActionId).ToList()
                      
          }).ToList();
    return roleDTOs;
    }
