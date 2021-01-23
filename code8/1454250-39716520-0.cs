    public class GridManager : GridManagerBase<IGridPointA, ITargetObject>
    {
    	void DoWork()
    	{
    		var result = GridTarget.HasVehicle; // works
            var result2 = SelectedTarget.SomeValue; // works with cast
    	}
    }
    public abstract class GridManagerBase<TGridPoint, TTargetObject> : IGridManagerBase<TGridPoint,TTargetObject> 
      where TGridPoint : class, IGridPointBase
      where TTargetObject : class, ITargetObjectBase
    {
    	public TGridPoint GridTarget { get; protected set; }
        public TTargetObject SelectedTarget { get; protected set; }
        //public IVehicleObjectBase SelectedVehicle { get; protected set; }
    }
    public interface IGridManagerBase<TGridPoint, TTargetObject>
    {
    	TGridPoint GridTarget { get; }
        TTargetObject SelectedTarget { get; }
    }
    public interface IGridPointBase
    {
    	int Row { get; }
    }
    public interface IGridPoint : IGridPointBase
    {
    	bool HasVehicle { get; }
    }
    public interface IGridPointA : IGridPointBase
    {
    	bool HasVehicle111 { get; }
    }
    public interface ITargetObjectBase
    {
    	int Row { get; set; }
    }
    public interface ITargetObject : ITargetObjectBase
    {
    	int SomeValue { get; }
    }
 
