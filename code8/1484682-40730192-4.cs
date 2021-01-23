    public abstract class FactoryBase
    {
    }
    public class Factory : FactoryBase
    {
    }
    public interface IHasFactory
    {
        FactoryBase Factory { get; }
    }
    [DataContract]
    public abstract class HasFactoryBase : IHasFactory
    {
        [DataMember(IsRequired = true)]
        FactoryBase factory;
        public FactoryBase Factory { get { return factory; } }
        public HasFactoryBase(FactoryBase factory)
        {
            this.factory = factory;
        }
    }
    [DataContract]
    public class Foo : HasFactoryBase
    {
        public Foo(FactoryBase factory)
            : base(factory)
        {
            this.Bars = new List<Bar>();
        }
        [DataMember]
        public List<Bar> Bars { get; set; }
    }
    [DataContract]
    public class Bar : HasFactoryBase
    {
        public Bar(FactoryBase factory) : base(factory) { }
    }
