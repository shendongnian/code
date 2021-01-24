    public class RebusPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            Console.WriteLine("Calling RebusPackage");
            container.ConfigureRebus(
                configurer => configurer
                    .Transport(t => t.UseInMemoryTransport(new InMemNetwork(), "test"))
                    .Start()
            );
        }
    }
