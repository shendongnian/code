    public class MyModelWrapper
    {
        public IList<IFormFile> Files { get; set; }
        [FromJson]
        public MyModel Model { get; set; } // <-- JSON will be deserialized to this object
    }
    // Controller action:
    public async Task<IActionResult> Upload(MyModelWrapper modelWrapper)
    {
    }
    // Add custom binder provider in Startup.cs ConfigureServices
    services.AddMvc(properties => 
    {
        properties.ModelBinderProviders.Insert(0, new JsonModelBinderProvider());
    });
