    public class PublicClass
    {
        public object PublicMethod()
        {
            return new List<InternalClass>() { new InternalClass() { b = 10 } };
        }
    }
