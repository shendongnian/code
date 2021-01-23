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
            }
        }
    
        public char ReadChar()
        {
            // lock the padlock so that no two threads try to read/write at the same time
    		lock (padlock)
    		{
    			return (char) result.Dequeue();
    		}
        }
    }
