    public static class Transitions
    {
    	private static Action[] TransitionStrategies = new Action[]
    	{
    		() => { /* One way of performing a transition */ },
    		() => { /* Another way of performing a transition */ },
    		() => { /* Keep adding methods and calling them here for each transition type */ }
    	}
    
    	public static void PerformTransition(int? transitionIndex = null)
    	{
    		int effectiveIndex;
    
    		// if the transition index is null, use a random one
    		if (transitionIndex == null)
    		{
    			effectiveIndex = new Random().Next(0, TransitionStrategies.Length);
    		}
    		else
    		{
    			effectiveIndex = transitionIndex.Value;
    		}
    
    		// perform the transition
    		TransitionStrategies[effectiveIndex]();
    
    	}
    }
