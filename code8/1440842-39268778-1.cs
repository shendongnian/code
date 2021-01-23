    public class model
    {
        int intValue;
        string stringValue;
        public object Getproperty(int index)
        {
            //select property by index
        }
    }
    
    public void baseClass<T>
        where T:model
    {   
		public T item;
        item.intValue; // access intValue
        item.stringValue; // access stringValue
    }
