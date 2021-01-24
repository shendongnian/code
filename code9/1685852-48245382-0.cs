    public class Program
    {
    	public static void Main()
    	{
    		new AllSteps().Process(1);
    	}
    	public interface IStep
    	{
    		void Process(int x);
    	}
    	public class StepOne:IStep
    	{
    		public void Process(int x)
    		{
    			// do something with x
    		}
    	}
    	public class StepTwo:IStep
    	{
    		public void Process(int x)
    		{
    			// do something with x
    		}
    	}
    	public class AllSteps:IStep
    	{
    		readonly List<IStep> steps= new List<IStep>();
    		
    		public AllSteps()
    		{
    			this.steps.Add(new StepOne());
    			this.steps.Add(new StepTwo());
    				
    		}
    		
    		public void Process(int x)
    		{
    			return steps.Select(y=>y.Process(x));
    		}
    	}
    }
