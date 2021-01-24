    public class InternalClassImplFactory
        {
            public static IPublicInterface MakeInternalClassImpl(IUnityContainer container)
            {
                return new InternalClassImpl();
            }
        }
