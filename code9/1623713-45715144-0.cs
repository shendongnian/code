    public interface IManagerFactory
    {
        BaseManager GetManager(BaseData dataObject);
    }
    public class UseFirstArgumentTypeAsNameInstanceProvider : StandardInstanceProvider
    {
        protected override string GetName(System.Reflection.MethodInfo methodInfo, object[] arguments)
        {
            return arguments[0].GetType().FullName;
        }
    }
    Bind<IManagerFactory>().ToFactory(() => new UseFirstArgumentTypeAsNameInstanceProvider());
    Bind<BaseManager>().To<Child1Manager>().Named(typeof(Child1Data).FullName);
    Bind<BaseManager>().To<Child2Manager>().Named(typeof(Child2Data).FullName);
