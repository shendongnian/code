     public class AirplaneFactory
     {
        private List<Type> _types = new List<Type>();
        //Implementation 1: Use an internal method to validate all items passed.
        public AirplaneFactory(IEnumerable<Type> airplaneTypes) 
        {
            AddTypes(airplaneTypes);
        }
        private void AddTypes(IEnumerable<Type> airplaneTypes)
        {
            var targetType = typeof(Airplane);            
            foreach (var item in airplaneTypes)
            {
                if (!item.IsSubclassOf(targetType))
                    throw new ArgumentException(string.Format("{0} does not derive from {1}", item.FullName, targetType.FullName));
                _types.Add(targetType);
            }
        }        
        //Implementation 2: Use a method to individually add the supported types
        public AirplaneFactory()
        {
        }
        //This method adds types one by one and validates the type
        public void AddType<T>() where T : Airplane
        {
            _types.Add(typeof(T));
        }               
    }
