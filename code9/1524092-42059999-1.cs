    class UnityObjectFactoty
    {
        public static TObject GetInstance<TObject>(IUnityContainer container)
        {
            return container.Resolve<TObject>();          
        }
    }
