    public class CharacterBuffer
    {
        private object padlock = new object();
        private Queue result;
    
        public CharacterBuffer()
        {
    		lock (padlock)
    		{
    			result = new Queue();
    		}
        }
    
        public void AddChar(char c)
        {
			lock (padlock)
    		{
				result.Enqueue(c);
				if (result.Count == 1)
				{
					// wake up any blocked dequeue
					Monitor.PulseAll(padlock);
				}
			}
        }
    
        public char ReadChar()
        {
    		lock (padlock)
    		{
				// wait until there is something in the queue
				while (result.Count == 0)
				{
					Monitor.Wait(padlock);
				}
			
    			return (char) result.Dequeue();
    		}
        }
    }
