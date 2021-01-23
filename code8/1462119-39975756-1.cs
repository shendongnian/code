    class InvokerClass
    {    
        private Object objInstance;
    
        public InvokerClass(Object obj)
        {
            if (obj == null) throw new ArgumentNullException("obj must not be null");
            this.objInstance = obj; //Get the passed Instance and use this to determine the Class Name
        }
        //Do invoking here
        public void StartInvokeExample(String data1, String data2)
        {   
            Type t = objInstance.GetType();
            object classObject = Activator.CreateInstance(t);
    
            MethodInfo m = t.GetMethod("thisMethod");
            m.Invoke(classObject, new object[] { data1, data2 });
        }
    }
