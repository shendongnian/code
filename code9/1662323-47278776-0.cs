    public DbSet Set(string name)
    {
      // you may need to fill in the namespace of your context
     return base.Set(Type.GetType(name));
    }
