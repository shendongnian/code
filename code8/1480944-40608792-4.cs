    public class CharacterBuffer
    {
        private object padlock = new object();
        private Queue result;
    
        public CharacterBuffer()
        {
            // lock the padlock so that nobody touches your queue until it is ready for use
    		lock (padlock)
    		{
    			result = new Queue();
    		}
        }
    
        public void AddChar(char c)
        {
            // lock the padlock so that no two threads try to read/write at the same time
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
            // lock the padlock so that no two threads tries to read/write at the same time
    		lock (padlock)
    		{
				// block the thread and wait until there is something in the queue
				while (result.Count == 0)
				{
                    Monitor.Wait(padlock);
				}
			
    			return (char) result.Dequeue();
    		}
        }
    }
