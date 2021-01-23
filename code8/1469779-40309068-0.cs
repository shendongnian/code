    public void GetCatsResult(string scenarioCats)
            {
                string item = this.GetType().Namespace + "." + scenarioCats; 
                // combined class string with the namespace
                Type className = Type.GetType(item);
                // found the class
                MethodInfo m = className.GetMethod("GetInfo");
                // get the method from class
                object value = m.Invoke(null,null);
                // invoke and value will represent the return value.
            }
