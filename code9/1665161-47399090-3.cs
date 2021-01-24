    var groups = context.UserGroups.Where(s => s.Users.Any(p => p.Username == username))
                                   .Select(e=>e.Id);
    var data = context.WidgetContents
                      .Include(s => s.Widget)
                      .Where(s => s.WidgetId == widgetId).ToList();
    var result= data.Where(s=>s.UserGroups.Any(e=>groups.Contains(e.Id))
                    .OrderByDescending(s => s.CreatedAt);
