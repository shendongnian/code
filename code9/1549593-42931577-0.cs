    public new static ICollection<Group> GetAll()
    {
        using (var provider = new GroupProvider())
        {
          provider.QAll().Include(a => a.RoleGroup.Select(c => c.Role))
                         .Include(a=>a.GroupLanguage.Select(b=>b.Language)).ToList();               
        }
    }
