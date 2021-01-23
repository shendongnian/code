    public class CharacterBuffer
    {
        private  static object Lock = new object();
        private Queue result;
    
        public CharacterBuffer()
        {
            result = new Queue();
           
        }
    
        public void addChar(char c)
        {
            lock(Lock)
            {
              result.Enqueue(c);
              Monitor.PulseAll(result);
            }
        }
    
        public char readChar()
        {
            lock(Lock)
            {
                 return (char) result.Dequeue();
            }
        }
    }
