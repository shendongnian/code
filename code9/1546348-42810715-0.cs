        public abstract class BaseClass<T>
        {
            public List<T> GetList(string someParameter)
            {
                // ...
                return result ?? new List<T>();
            }
        }
        public class BaseClassImplementation 
          : BaseClass<BaseClassImplementation > // speciffic implementation
        {
            // .....
        }
