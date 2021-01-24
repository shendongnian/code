     List<ApplicationUserListViewModel> list = new List<ApplicationUserListViewModel>();
            
    foreach (var user in _userManager.Users.ToList())
     {              
            list.Add(new ApplicationUserListViewModel() {
                    UserEmail = user.Email,
                    Roles = await _userManager.GetRolesAsync(user)
                });
     }
