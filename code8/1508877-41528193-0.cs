    [HttpPost]
            public JsonResult printUser(User user)
            {
                user.DisplayName = user.DisplayName.Replace("\n", String.Empty);
                user.DisplayName = user.DisplayName.Trim(' ');
               
                User findUser = UserAdapter.GetUserByUserName(user.DisplayName);
    
                return Json(new { displayName = findUser.DisplayName});
            } 
