    internal class TypedFactory : ITypedFactory
    {
        public ITyped Create(Type type)
        {
            return new Typed(type);
        }
    }
    internal interface ITypedFactory
    {
        ITyped Create(Type type);
    }
    container.RegisterType<ITypedFactory, TypedFactory>();
    
    Assert.AreEqual(
        container.Resolve<ITypedFactory>().Create(typeof(string)).Type,
         typeof(string));
