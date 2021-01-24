    public interface IItem<out T> where T : SomeObject
    {
        T Item { get; }
    }
    public class ConcreteItem1 : IItem<ClassExtendingSomeObject>
    {
        public ClassExtendingSomeObject Item { get; }
    }
    public class ConcreteItem2 : IItem<AnotherClassExtendingSomeObject>
    {
        public AnotherClassExtendingSomeObject Item { get; }
    }
