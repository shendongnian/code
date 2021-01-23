    public UserMap()
    {
        Table("Users");
        Id(x => x.Id, m =>
        {
            m.Generator(Generators.GuidComb);
        }
        ...
