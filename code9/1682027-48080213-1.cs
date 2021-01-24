    public class MyUnityExtension : UnityContainerExtension
    {
        private readonly ISettings _settings;
        public MyUnityExtension(ISettings settings)
        {
            _settings = settings;
        }
        ...etc
    }
