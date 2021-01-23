    using (Model1 ent = new Models.Model1())
    {
        var regionID= new SqlParameter("@RegionID", 100);
        var regionDesc= new SqlParameter("@RegionDesc", "Nima");
        ent.Database.SqlQuery<Region>("InsertRegion @RegionID ,@RegionDesc", regionID ,regionDesc);
    }
