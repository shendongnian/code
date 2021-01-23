    return new RoleService()
    .GetAll()
    .Select(r => new SelectItem
    {
        Text = r.Name,
        Value = r.Id.ToString(),
        Selected = roles.Any(ar => ar.Id == r.Id)
    })
    .ToList();
