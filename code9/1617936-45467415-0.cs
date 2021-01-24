    public static IEnumerable<SelectListItem> GetJurisdictions()
    {
        using (var context = new DAL.ObservationEntities())
        {
            List<SelectListItem> JurisdictionsList = new List<SelectListItem>();
            var items = (from j in context.Jurisdictions orderby j.Name select j); // Removed toList()
            foreach (var item in items)
            {
                JurisdictionsList.Add(new SelectListItem() { Text = item.Name.ToString(), Value = item.GUID.ToString() });
            }
            return JurisdictionsList;
        }
    }
