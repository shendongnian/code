    public class EmailProviderFactory
    {
        private readonly Container container;
        public EmailProviderFactory(Container container)
        {
            this.container = container;
        }
        public IEmailOutputService Create(string provider)
        {
            switch (provider)
            {
                case "Mandrill": // should be in a constants class
                    return container.GetInstance<MandrillOutputService>();
                
                case "Other":  // should be in a constants class
                     return container.GetInstance<OtherOutputService>();
                
                default: throw new ArgumentOutOfRangeException("provider");
            }
        }
    }
