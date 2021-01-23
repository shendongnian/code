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
              claims = new ClaimDTO
                    {
                        ActionID = a.ActionID;
                        ActionCode = a.ActionCode;
                        Type = a.Type;
                        ActionLevel = a.ActionLevel;
                    }  
                      
          }).ToList();
    return roleDTOs;
    }
