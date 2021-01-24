    public struct Wrapper
    {
        public System.Type T;
        public object delegateObject;
        public void Invoke(DataTypeBase data)
        { 
           ((Delegate)delegateObject).DynamicInvoke(data); //Will compile
        }
    }
