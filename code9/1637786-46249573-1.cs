    public class CustomClass
    {
        public CustomClass(){}
    
        public MonoBehaviour getCreator()
        {
            //Access MonoBehaviour from the dictionary
            MonoBehaviour result;
            TestMono.classToMonoBehaviour.TryGetValue(this, out result);
            return result;
        }
    }
