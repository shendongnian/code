    public class GenericArgumentEqualityComparer : IEqualityComparer<Type>
        {
            public bool Equals(Type x, Type y)
            {
            
                var xInterfacesTypes = x.GetInterfaces();
                var yInterfacesTypes = y.GetInterfaces();
                if (!xInterfacesTypes.Any()&&!yInterfacesTypes.Any() )
                {
                    return true; 
                }
                if ((!xInterfacesTypes.Any() && yInterfacesTypes.Any()) || xInterfacesTypes.Any() && !yInterfacesTypes.Any())
                {
                    return false; 
                }          
                foreach (var xInterfacesType in xInterfacesTypes)
                {
                    var iType = xInterfacesType.IsGenericType ? xInterfacesType.GetGenericTypeDefinition() :xInterfacesType;
                    var yType = yInterfacesTypes.Any(yI => yI.IsGenericType && yI.GetGenericTypeDefinition() == iType||yI.GetType()==xInterfacesType.GetType());
                    if (!yType)
                    {
                        return false;
                    }
                        
                }
                return true; 
            }
    
            public int GetHashCode(Type obj)
            {
                return obj.Name.GetHashCode(); 
            }
        }
