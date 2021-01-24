      public static class AnimalsTypeProvider
    {
        public static IEnumerable<Type> GetAnimalsTypes(ICustomAttributeProvider provider)
        {
            //Get all types that implement animals. 
            //If there is more interfaces or abtract types that been used in the service can be called for each type and union result            
            IEnumerable<Type> typesThatImplementIAnimal = GetAllTypesThatImplementInterface<IAnimal>();
            
            return typesThatImplementIAnimal;
        }
        
        public static IEnumerable<Type> GetAllTypesThatImplementInterface<T>()
        {
            Type interfaceType = typeof(T);
            //get all aseembly in current application
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            List<Type> typeList = new List<Type>();
            //get all types from assemblies
            assemblies.ToList().ForEach(a => a.GetTypes().ToList().ForEach(t => typeList.Add(t)));
            //Get only types that implement the IAnimal interface
            var alltypesThaImplementTarget =
                typeList.Where(t => (false == t.IsAbstract) && t.IsClass && interfaceType.IsAssignableFrom(t));
            return alltypesThaImplementTarget;
        }        
    }
