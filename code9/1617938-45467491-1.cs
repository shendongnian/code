    public static IEnumerable<SelectListItem> GetJurisdictions()
    {
    	using (var context = new DAL.ObservationEntities())
    	{
    		var items = (from j in context.Jurisdictions orderby j.Name select new { j.Name, j.GUID })
    					.AsEnumerable()
    					.Select(j => new SelectListItem { Text = j.Name, Value = j.GUID.ToString() })
    					.ToList();
    
    		return items;
    	}
    }
