    public class CharacterBuffer
    {
        private  static object Lock = new object();
        private Queue result;
    
        public CharacterBuffer()
        {
            result = new Queue();
            //lock (result);  <-- this is WRONG
        }
    
        public void addChar(char c)
        {
            Monitor.Enter(Lock){
                    result.Enqueue(c);
            }
            Monitor.Pulse(Lock);
        }
    
        public char readChar()
        {
            char c;
            Monitor.Wait(result);
            Monitor.Enter(Lock){
                c = (char)result.Deqeueue(); 
            }
            return c;
        }
    }
