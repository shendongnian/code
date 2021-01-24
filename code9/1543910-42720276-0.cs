    public ActionResult GetUserList(string searchRequest)
    {
        if (searchRequest == "All")
        {
           var users = db.user
               .Select(user => new {user.Name, user.Address.ZipCode})
               .ToList();
           return ToJson(users);
        }
        else if (searchRequest == "Flight") 
        {
            List<User> users = db.user
                .Where(t => t.type_id == (int)ServiceTypeEnum.Flight)
                .ToList();
            return ToJson(users);
        }
        return ToJson(new List<User>());
    }
    private ActionResult ToJson<T>(T list)
    {
        return Json(new { data = list });
    }
