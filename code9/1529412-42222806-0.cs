      var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
      services.AddTransient<IValidator<FooEntity>, RealValidator<FooEntity>>();
      services.AddTransient<Foo>();
      var serviceProvider = services.BuildServiceProvider();
      var validator = serviceProvider.GetService<IValidator<FooEntity>>();
      var foo = serviceProvider.GetService<Foo>();
      Assert.NotNull(validator);
      Assert.NotNull(foo);
