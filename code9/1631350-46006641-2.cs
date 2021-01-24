        private bool AreParametersEquals(Dictionary<string, Type> parameters)
        {   
            if((parameters == null) && (Parameters == null)) return true;
            if((parameters == null) || (Parameters == null)) return false;
            if(parameters.Count != Parameters.Count) return false;
            var paramArray1 = parameters.OrderBy(p => p.Key).ToArray();
            var paramArray2 = Parameters.OrderBy(p => p.Key).ToArray();
            for(int i = 0; i < paramArray1.Length; i++)
            {
                if(!string.Equals(paramArray1[i].Key, paramArray2[i].Key)) return false;
                if(!string.Equals(paramArray1[i].Key, paramArray2[i].Key)) return false;
            }
            return true;
        }
        private bool AreReturnTypeEquals(Type returnType)
        {
            if((returnType == null) && (ReturnType == null)) return true;
            return (returnType != null) && returnType.Equals(ReturnType);
        }
        private bool AreMethodNameEquals(string methodName)
        {
            // Ensuring case sensitive using IEquatable<string>
            return string.Equals(methodName, MethodName);
        }
        private bool AreClassNameEquals(string className)
        {
            // Ensuring case sensitive using IEquatable<string>
            return string.Equals(className, ClassName);
        }
        private bool AreAssemblyNamesEqual(string assemblyName)
        {
            // Ensuring case sensitive using IEquatable<string>
            return string.Equals(assemblyName, AssemblyName);
            
        }
