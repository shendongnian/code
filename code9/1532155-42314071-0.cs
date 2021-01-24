    public JwtContext() : base("name=Jwt")
        {
            Database.SetInitializer(new JwtDbInitializer<JwtContext>());
            using (JwtContext context = new JwtContext())
            {
                context.Database.Delete();
            }
        }
