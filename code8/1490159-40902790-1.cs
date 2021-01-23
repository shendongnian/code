    public interface IInfo<in T> : IInfo 
    	where T : IInput
    {
    	//new T Input { get; }
    }
