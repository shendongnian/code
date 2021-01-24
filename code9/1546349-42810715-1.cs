        public abstract class BaseClass<T>
            where T : BaseClass<T>, new()
        {
            public List<T> GetList(string someParameter)
            {
                return new List<T>() { new T() };
            }
        }
        public class BaseClassImplementation : BaseClass<BaseClassImplementation>
        {
            // ..............
        }
