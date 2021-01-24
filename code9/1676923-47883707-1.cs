        public async Task<IActionResult> OnGetAsync()
        {
            UserList = _userManager.Users.ToList();
            UserRoleList = new List<string>();
            RoleList = new List<string>();
            return Page();
        }
        public async Task<IActionResult> OnPostGetRolesAsync()
        {
            UserList = _userManager.Users.ToList();     // You have to reload
            var user = await _userManager.FindByNameAsync(Input.User);
            UserRoleList =  await _userManager.GetRolesAsync(user);
            return Page();
        }
