    [Authorize]
    [Route("api/FirstTest/{SysId}")]
    public List<String> Name(long SYSID)
    {
        using (SpaContext db = new SpaContext())
        {
            var query = db.firsttests.Where(a => 1 == 1);
            if (!String.IsNullOrEmpty(SYSID.ToString()))
            {
                query = query.Where(a => a.SysId.Equals(SYSID));
            }
            return query.Select(a => a.Name).ToList();
        }
    }
