    public List<SelectItem> GetSelectedRoles(List<Role> roles)
    {
        roles = roles ?? new List<Role>();
        return new RoleService(this.unitOfWork) // always pass unitOfWork
        .GetAll()
        .Select(r => new SelectItem
        {
            Text = r.Name,
            Value = r.Id.ToString(),
            Selected = roles.Any(ar => ar.Id == r.Id)
        })
        .ToList();
    }
