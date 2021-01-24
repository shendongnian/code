    //you called POST /blog
    string resource = "blog";
    string body = "{...}";
    var context = new FooContext();
    
    IEntityType entityType = context.Model
        .GetEntityTypes()
        .First(x => x.Name.EndsWith($".{resource}", StringComparison.OrdinalIgnoreCase));
    
    //This type should be "MyAssembly.Blog" - exact entity CLR type.
    //Another option to get this CLR type is assembly scan.
    Type type = entityType.ClrType;
    //having type, it is possible to create instance
    object entity = JsonConvert.DeserializeObject("body", type);
    //var entity = Activator.CreateInstance(type);
    
    context.Entry(entity).State = EntityState.Added;
    context.SaveChanges();
