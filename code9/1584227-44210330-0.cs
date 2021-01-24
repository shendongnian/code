    public class Timer
    {    
        private static float _baseTime = 0;
        
        public static float Time { get { return Time.time - _baseTime; } }
            
        public static void Reset()
        {
            _baseTime = Time.time;
        }
    }
