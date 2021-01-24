    public class TestController : Controller
    {
        private readonly ApplicationPartManager _partManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        public TestController(
            ApplicationPartManager partManager,
            IHostingEnvironment env)
        {
            _partManager = partManager;
            _hostingEnvironment = env;
        }
        public IActionResult RegisterControllerAtRuntime()
        {
            string assemblyPath = @"PATH\ExternalControllers.dll";
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
            if (assembly != null)
            {
                _partManager.ApplicationParts.Add(new AssemblyPart(assembly));
                // Notify change
                MyActionDescriptorChangeProvider.Instance.HasChanged = true;
                MyActionDescriptorChangeProvider.Instance.TokenSource.Cancel();
                return Content("1");
            }
            return Content("0");
        }
    }
