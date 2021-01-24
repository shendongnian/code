    protected override void Seed(MyContext context)
    {
        context.Properties.AddOrUpdate(x => x.Value,
            new Property() { Value = "My Prop Name 1", Property_Name = 1, Type = 1 },
            new Property() { Value = "My Prop Name 2", Property_Name = 2, Type = 2 },
            new Property() { Value = "My Prop Name 3", Property_Name = 3, Type = 1 }
            );
    }
