    public class CharacterBuffer
    {
        private static object padlock = new object();
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
            }
        }
    
        public char ReadChar()
        {
    		lock (padlock)
    		{
    			return (char) result.Dequeue();
    		}
        }
    }
