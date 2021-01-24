    List<(int ID, string FirstName, string LastName)> queryResults = new List<(int ID, string FirstName, string LastName)>();
    using (var db = new MyDatabase())
    {
        queryResults.AddRange(
            (
                from u in db.Users
                select new { u.ID, u.FirstName, u.LastName }
            )
            .AsEnumerable()
            .Select(r => (r.ID, r.FirstName, r.LastName))
        );
    }
