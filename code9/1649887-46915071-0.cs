        public class MyContentManager : ContentManager
        {
            public MyContentManager(IServiceProvider serviceProvider):base(serviceProvider)
            {
            }
    
            public MyContentManager(IServiceProvider serviceProvider, string rootDirectory) : base(serviceProvider, rootDirectory)
            {
                
            }
    
            public void Unload(string name)
            {
                // unload specific resource
                LoadedAssets.Remove(name);
            }
    
            public Texture2D Load(string name)
            {
                return Load<Texture2D>(name);
            }       
        }
    
