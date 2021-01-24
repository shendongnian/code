    public IEnumerable GetLicensee()
    {
            using (var db = new DataModelContext())
            {
            IEnumerable query = (from b in db.User.Include(u => u.Addresses)
                         select new { UserName= b.UserName,Address=b.Addresses }).ToList();
                return query;
            }
     }
