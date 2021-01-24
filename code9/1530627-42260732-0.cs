    class Program
    {
        static void Main()
        {
            var simpleFactory = new SimpleFactory();
            var entity = simpleFactory.Create(1);
            entity.Something();
        }
    }
    public abstract class EntityBase
    {
        public abstract ushort ID { get; }
        public abstract void Something();
    }
    public class TestEntity : EntityBase
    {
        public override ushort ID { get { return 1; } }
        public override void something() { }
    }
    public class OtherEntity : EntityBase
    {
        public override ushort ID { get { return 2; } }
        public override void something() { }
    }
    public class SimpleFactory
    {
        private Dictionary<ushort, Func<EntityBase>> config = new Dictionary<ushort, Func<EntityBase>>
        {
            { 1, ()=>new TestEntity()},
            { 2, ()=>new OtherEntity()},
        };
        public EntityBase Create(ushort entityId)
        {
            if (!config.ContainsKey(entityId))
                throw new InvalidOperationException();
            return config[entityId]();
        }
    }
