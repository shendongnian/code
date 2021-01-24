    public class Response<T> where T: IRepsonses, new()
    {
        public string ResponseCode { get; set; }
        public T Object { get; set; }
        public List<T> Objects { get; set; }
        public Response()
        {
        }
    }
    public interface IRepsonses
    {
    }
    public class ChildrenResponses : IRepsonses
    {
        public ChildrenResponses() // constructor
        {
        }
        public string ChildSays { get; set; }
        // some properties
    }
    public class AdultResponses : IRepsonses
    {
        public AdultResponses() // constructor
        {
        }
        public string AdultSays { get; set; }
        // some properties
    }
    class Program
    {
        public static Response<T> GetSpecificResponseType<T>() where T: IRepsonses, new()
        {
            // ... some logic to instantiate a Response<> object using the parameter type passed into the method.
            // ... some logic to set the generic properties of Response<> object based on the parameter type passed into the method.
            // return object
            T obj = new T();
            return new Response<T>()
            {
                Object=obj,
                Objects=new List<T>()
            };
        }
        static void Main(string[] args)
        {
            var resp = GetSpecificResponseType<AdultResponses>();
            var adult = resp.Object.AdultSays;
        }
    }
