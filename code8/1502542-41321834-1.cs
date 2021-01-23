    using (Model1 ent = new Models.Model1())
    {
        List<SqlParameter> parameters = new List<SqlParameter>();
        parameters.Add(new SqlParameter("RegionID", 100));
        parameters.Add(new SqlParameter("RegionDesc", "Nima"));
        ent.Database.SqlQuery<Region>("InsertRegion", parameters.ToArray());
    }
