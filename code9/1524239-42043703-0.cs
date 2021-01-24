    class Program
    {
        static void Main(string[] args)
        {
            var o1 = new ObjectBasicFeatures();
            var o2 = new ObjectBasicFeatures(o1);
            System.Diagnostics.Debug.Assert(!o1.Equals(o2));
        }
    }
    public class ObjectBasicFeatures
    {
        public ObjectBasicFeatures()
        {
            MyProperty = 0;
        }
        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="other"></param>
        public ObjectBasicFeatures(ObjectBasicFeatures other)
        {
            MyProperty = other.MyProperty;
        }
        public int MyProperty { get; set; }
    }
