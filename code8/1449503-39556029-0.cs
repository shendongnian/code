    public class CriticalSectionSlim<TKey>
    {
    	private readonly HashSet<TKey> lockSet = new HashSet<TKey>();
    	public void Enter(TKey key)
    	{
    		lock (lockSet)
    		{
    			while (!lockSet.Add(key))
    				Monitor.Wait(lockSet);
    		}
    	}
    	public void Exit(TKey key)
    	{
    		lock (lockSet)
    		{
    			lockSet.Remove(key);
    			Monitor.PulseAll(lockSet);
    		}
    	}
    }
