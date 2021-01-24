    public ActionResult GetUserList(string searchRequest)
    {
        try
        {
            List<UserSearchResult> UserList = new List<UserSearchResult>();
            if (searchRequest != null)
            {
                if (searchRequest == "All")
                {
                    UserList.AddRange(db.user.Select(u => new UserSearchResult { Title = u.Title, FirstName = u.Firstname, LastName = u.Lastname })); // here i want to write select query but how i don't know
                }
                else if (searchRequest == "Flight")
                {
                    UserList.AddRange(db.user.Where(t => t.type_id == (int)ServiceTypeEnum.Flight)
                        .Select(u => new UserSearchResult { Title = u.Title, FirstName = u.Firstname, LastName = u.Lastname }));
                }
            }
            return Json(new { data = UserList });
        }
        catch (Exception ex)
        {
            throw;
        }
        return Json(null);
    }
    public class UserSearchResult
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
