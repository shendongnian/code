        private readonly List<Type> _alreadyVisitedTypes = new List<Type>(); //avoid infinite recursion
        private void RecursivelySetTypesToOperateOn(Type currentType)
        {
            if (_alreadyVisitedTypes.Contains(currentType))
            {
                return;
            }
            _alreadyVisitedTypes.Add(currentType);
            if (currentType.IsClass && currentType.Namespace != "System") //custom defined classes only
            {
                _types.Add(currentType);
            }
            foreach (PropertyInfo pi in currentType.GetProperties())
            {
                if (pi.PropertyType.IsClass)
                {
                    RecursivelySetTypesToOperateOn(pi.PropertyType);
                }
            }
        }
