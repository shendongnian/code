    public interface IVMBase
    {
    string ParentPropertyName { get; }
    string ParentForeignKeyPropertyName { get; }
    string ChildsPropertyName { get; }
    bool EnableChangeParent { get; set; }
    ChangeHierarchyParentArgs<Entity> ChangeEntityParent { get;  }
    }
    public interface IVMBase<out T> : IVMBase where T : Entity
    {
        new ChangeHierarchyParentArgs<T> ChangeEntityParent { get; }
    }
    public abstract class VM<T> :  IVMBase<T> where T : Entity
    {
        public ChangeHierarchyParentArgs<T> ChangeEntityParent { get; }
    }
