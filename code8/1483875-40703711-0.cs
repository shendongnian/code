    var conString="your database connection string here";
    using (var conn =   new SqlConnection(conString))
    {
        conn.Open();
        string qry = "SELECT S.SiteId, S.Name, S.Description, L.LocationId,  L.Name,L.Description,
    				  L.ReportingId
                      from Site S  INNER JOIN   
                      Location L ON S.SiteId=L.SiteId";
        var sites = conn.Query<Site, Location, Site>
                         (qry, (site, loc) => { site.Locations = loc; return site; });
        var siteCount = sites.Count();
        foreach (Site site in sites)
        {
            //do something
        }
        conn.Close(); 
    }
