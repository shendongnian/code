    public IEnumerable GetLicensee()
    {
            using (var db = new DataModelContext())
            {
            IEnumerable query = (from b in db.User.Include("Addresses")
                         select new { UserName= b.UserName,Address=b.Addresses }).ToList();
                return query;
            }
     }
