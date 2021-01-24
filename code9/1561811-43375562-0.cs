    // ------------ Assembly A -----------------
	public abstract class AbstractTypedClass<T>
	{
		public abstract void ExecuteInheritedFunction(T obj);
	}
    // ------------ Assembly B -----------------
    IHugeDependency
    {
        void execute1();
        ...more
    }
    
	public class FirstTypedClass : AbstractTypedClass<IHugeDependency>
	{
		public override void ExecuteInheritedFunction(IHugeDependency obj)
		{
			// do shizzle for the first typed class
			obj.execute1();
		}
	}
    // ------------ Assembly C -----------------
    ISmallerDependency
    {
        void execute2();
    }
	public class SecondTypedClass : AbstractTypedClass<ISmallerDependency>
	{
		public override void ExecuteInheritedFunction(ISmallerDependency obj)
		{
			// do shizzle for the second typed class
			obj.execute2();
		}
	}
