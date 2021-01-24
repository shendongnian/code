    public abstract class Airplane{}
    public abstract class Fighter:Airplane{}
    
    public class F15 : Fighter{}
    public class F16 : Fighter{}
    public class Boeing747 : Airplane{}
    
    public class AirplaneFactory<T> where T : Airplane
    {
        List<T> list = new List<T>();
    	public void Add(T plane) => list.Add(plane); //"Add" used as a general example, but something like "Create" can be used as well. If T itself should be creatable directly, the constraint 'where T: Airplane, new()' can be used
    }
