    public class Answer
    {
        public static bool Exists(int[] ints, int k)
        {
            var i = 0;
            var hasValue = false;
    
            while(i < ints.Length && !hasValue)
            {
                hasValue = ints[i] == k;
                ++i;
            }
    
            return hasValue;
        }
    }
