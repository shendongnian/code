    var appuser = context
                            .ApplicationUser
                            .Where(e => e.UserId == _userId)
                            .FirstOrDefault();
							
    appuser.TotalBalance += model.Amount;
    context.ApplicationUser.Update(appuser);
