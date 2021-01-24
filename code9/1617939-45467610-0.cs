    public static IEnumerable<SelectListItem> GetJurisdictions()
    {
        using (var context = new DAL.ObservationEntities())
        {
            var query = from j in context.Jurisdictions 
                        orderby j.Name
                        select new SelectListItem {
                            Text = item.Name,
                            Value = item.GUID.ToString(),
                        };
            return query.ToList();
        }
    }
