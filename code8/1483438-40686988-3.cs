    public class Foo<T>
    {
        private ISerializer<T> _serialiser;
 
        public Foo<T>(ISerializer<T> serialiser)
        {
            _serialiser = serialiser;
        }
        void DoFoo()
        {
            string result = serialiser.Serialize(instanceOfA_1);
            var instanceOfA_2 = serialiser.Deserialize<ClassA>(result);
        }
    }
