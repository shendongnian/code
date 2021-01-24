    public interface IEntity { }
    public class Entity1 : IEntity { }
    public class Entity2 : IEntity { }
    
    public interface IEntityModelBuilder<out T> { }
    
    public class BaseClass1 : IEntityModelBuilder<Entity1>
    {        
        public BaseClass1(int a) { }
    }
    public class BaseClass2 : IEntityModelBuilder<Entity2>
    {
        public BaseClass2(int a) { }
    }
