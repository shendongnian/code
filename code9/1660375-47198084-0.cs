    var lstAuthorizedUsersRaw = dbsp.SP_GetPrivilegesByUsername(inUsername.Trim());
    authEntity.Controllers = lstAuthorizedUsersRaw
          .GroupBy(p => p.Cntrollers_Name)
          .Select(controllerGroup => new AuthController {
             Name = controllerGroup.Key,
             Actions = controllerGroup
                        .GroupBy(p => p.HMVAct_Name) // here
                        .Select(actionGroup => new AuthAction {
                            Name = actionGroup.Key,
                            Methods = actionGroup.Select(pu => p.HMVMethd_Name).ToList()
                        }).ToList()
          }).ToList();
       
