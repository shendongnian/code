    public void ConfigureServices(IServiceCollection services)
    {
      var controllersAssembly = Assembly.Load(newAssemblyName("SomeProject.MeetTheControllers"));
    
      services.AddMvc().AddApplicationPart(controllersAssembly).AddControllersAsServices();
    }
