    using System;
    public class Program
    {
        public static void Main()
        {
    		Activity goJump = Activity.Go | Activity.Jump;
    		
    		Activity activity =
    		    CreateActivity(
    				go:    true,
    				stand: false,
    				jump:  true,
    				run:   false);
    					
    		Console.WriteLine(activity == goJump); // prints "True"
        }
    
        public static Activity CreateActivity(bool go, bool stand, bool jump, bool run)
        {
    		return
    			(go    ? Activity.Go    : 0) |
    			(stand ? Activity.Stand : 0) |
    			(jump  ? Activity.Jump  : 0) |
    			(run   ? Activity.Run   : 0);
        }
    }
    
    [Flags]
    public enum Activity
    {
        None = 0,
        Go = 1,
        Stand = 2,
        Jump = 4,
        Run = 8,
    }
