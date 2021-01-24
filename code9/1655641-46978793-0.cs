    var _do = new Do();
    		
    _do.Register<I1>(() => Console.WriteLine("I1 action"));
    _do.Register<I2>(() => Console.WriteLine("I2 action"));
    		
    _do.Work<I1>();
    _do.Work<I2>();
    _do.Work<string>();
    
    public class Do {
    	IDictionary<object, Action> actions = new Dictionary<object, Action>();
    	
    	private void DefaultAction(){
    		Console.WriteLine("Default action called");
    	}
    	
    	public void Register<T>(Action act){
    		var type = typeof(T);
    		if(!actions.ContainsKey(type)){
    			actions.Add(type, act);
    		}
    	}
    	
    	public void Work<T>() 
    	{
    		var type = typeof(T);
    		if(actions.ContainsKey(type))
    		{
    			actions[type]();
    		}
    		else
    		{
    			DefaultAction();
    		}
    	}
    }
    
    public interface I1 { }
    
    public interface I2 { }
