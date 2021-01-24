    public List<SelectListItem> Dropdown()
    {
      return new GenericRepository<Supportwife>(_factory.ContextFactory)
                     .Get()
                     .Select(st => new SelectListItem()
      {
        Text = st.Name,
        Value = st.TypeID.ToString(),
      }).ToList();
    }
