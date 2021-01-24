    var assembly = Assembly.GetExecutingAssembly();
    var projResource = new ResourceManager("ResourcesDemo.Properties.Resources", assembly);
    var customResource = new ResourceManager("ResourcesDemo.Custom", assembly);
    Console.WriteLine(projResource.GetString("DBO_LISTA_URLS_TEST"));
    Console.WriteLine(customResource.GetString("CUSTOM_RESOURCE"));
