    void Main() {
    	var cmd = new Commands();
    
    	while (!cmd.Exitting) {
    		var cmdline = Console.ReadLine();
    		var cmdargs = Regex.Split(cmdline.Trim(), @"\s+");
    		if (!cmd.TryInvokeMember(cmdargs[0], cmdargs.Skip(1).ToArray()))
    			Console.WriteLine($"Unknown command: {cmdargs[0]}");
    	}
    }
    
    // Define other methods and classes here
    public class Commands {
    	public bool Exitting { get; private set; }
    
    	public Commands() {
    		Exitting = false;
    	}
    
    	public void exit() {
    		Exitting = true;
    	}
    
    	public int sum(object[] args) {
    		return args.Select(s => Convert.ToInt32(s)).Sum();
    	}
    
    	public bool TryInvokeMember(string methodName, object[] args) {
    		var method = typeof(Commands).GetMethod(methodName.ToLower());
    
    		if (method != null) {
    			object res;
    			if (method.GetParameters().Length > 0)
    				res = method.Invoke(this, new object[] { args });
    			else
    				res = method.Invoke(this, new object[0]);
    				
    			if (method.ReturnType != typeof(void))
    				Console.WriteLine(res.ToString());
    
    			return true;
    		}
    		else
    			return false;
    	}
    }
