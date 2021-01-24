        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
    with
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            ResourceContentManager resxContent;
            resxContent = new ResourceContentManager(Services, Resources.ResourceManager);
            Content = resxContent;
        }
