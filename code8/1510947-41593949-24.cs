    public static class ServiceLocator
    {
        private static IContainer container;
        public static IContainer Container
        {
            get 
            {
                if (container == null)
                {
                    container = new Container();
                }
                return container;
            }
        }
    }
