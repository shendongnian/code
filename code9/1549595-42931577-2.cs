    public new static ICollection<GroupDTO> GetAll()
    {
        using (var provider = new GroupProvider())
        {
          provider.QAll().Include(a => a.RoleGroup.Select(c => c.Role))
                         .Include(a=>a.GroupLanguage.Select(b=>b.Language))
                         .Select(a=>new GroupDTO{GroupName=a.Name, 
                                                 Language=a.GroupLanguage.Select(b=>b.Language)
                                                                         .Where(c=>c.LanguageName=="ENG")})
                         .ToList();               
        }
    }
   
