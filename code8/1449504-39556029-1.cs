    public class CriticalSectionSlim<TKey>
    {
    	const int EnteredFlag = int.MinValue;
    	private readonly Dictionary<TKey, int> lockInfo = new Dictionary<TKey, int>();
    	public void Enter(TKey key)
    	{
    		lock (lockInfo)
    		{
    			int info;
    			if (lockInfo.TryGetValue(key, out info))
    			{
    				if ((info & EnteredFlag) != 0)
    				{
    					lockInfo[key] = info + 1;
    					do
    					{
    						Monitor.Wait(lockInfo);
    						info = lockInfo[key];
    					}
    					while ((info & EnteredFlag) != 0);
    					info--;
    				}
    			}
    			lockInfo[key] = EnteredFlag | info;
    		}
    	}
    	public void Exit(TKey key)
    	{
    		lock (lockInfo)
    		{
    			int waitCount = lockInfo[key] & ~EnteredFlag;
    			if (waitCount == 0)
    				lockInfo.Remove(key);
    			else
    			{
    				lockInfo[key] = waitCount;
    				Monitor.PulseAll(lockInfo);
    			}
    		}
    	}
    }
