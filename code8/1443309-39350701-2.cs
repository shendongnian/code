    using (DataContext ctx = new DataContext())
    {
        var results = (from m in ctx.MeritBadges
                       select new SelectListItem
                       {
                           Value = m.ID.ToString(),
                           Text = m.MeritBadgeName
                        }
                       ).OrderBy(o => o.Text);
        return new SelectList(results, "Value", "Text");
    }
