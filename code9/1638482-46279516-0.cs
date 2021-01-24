    public class Task
    {
    	public string Name {get;set;}
    	public string ResourceName {get;set;}
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		List<Task> Tasks = new List<Task>();
    		Tasks.Add(new Task(){Name = "a",ResourceName = "ra"});
    		Tasks.Add(new Task(){Name = "b",ResourceName = "rb"});
    		Tasks.Add(new Task(){Name = "c",ResourceName = "rc"});
    		Tasks.Add(new Task(){Name = "a",ResourceName = "ra"});
    		Tasks.Add(new Task(){Name = "b",ResourceName = "rb"});
    		Tasks.Add(new Task(){Name = "c",ResourceName = "rc"});
    		
    		Console.WriteLine("Initial List :");
    		foreach(var t in Tasks){
    			Console.WriteLine(t.Name);	
    		}
    		
    		// Here comes the interesting part
    		List<Task> Tasks2 = Tasks.GroupBy(x => new {x.Name, x.ResourceName})
                                     .Select(g => g.First()).ToList();
    		
    		Console.WriteLine("Final List :");
    		foreach(Task t in Tasks2){
    			Console.WriteLine(t.Name);	
    		}
    	}
    }
