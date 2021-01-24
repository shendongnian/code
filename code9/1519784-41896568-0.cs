    public IEnumerable<SelectListItem> GetListItems()
    {
        // assumes `context` is a field on your class,
        // set in the contructor, after being injected
        return context.Table1
            .Where(x => x.deleted == false)
            .GroupBy(x => x.Table2.Property1)
            .Select(x => {
                var group = new SelectListGroup { Name = x.Key };
                return x.Select(i => new SelectListItem
                {
                    Text = i.PropertyText,
                    Value = i.ID.ToString(),
                    Group = group
                });
            })
            .SelectMany(x => x);
            
    }
