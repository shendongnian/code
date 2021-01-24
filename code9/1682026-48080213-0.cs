    public class MyUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMyType, MyImpl1>(nameof(MyImpl1));
            Container.RegisterType<IMyType, MyImpl2>(nameof(MyImpl2));
            Container.RegisterType<IMyType, MyImpl3>(nameof(MyImpl3));
        }
    }
