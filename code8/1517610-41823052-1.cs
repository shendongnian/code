    //public ContextDB Context { get; set; }
    private SelectListItem[] AvailableSpecialties()
    {
        using(var Context = new MyContext())
        {
             return Context.Specialties.ToList()
               .OrderBy(t => t.Title)
               .Select(t => new SelectListItem
               {
                  Text = t.Title,
                  Value = t.ID.ToString()
               }).ToArray();
        }
    }
