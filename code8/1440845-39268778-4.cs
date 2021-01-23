    public interface IIndexedProperty
    {
        object Getproperty(int index);
    }
    
    public class model:IIndexedProperty
    {
        int intValue;
        string stringValue;
        public object Getproperty(int index)
        {
            //select property by index
        }
    }
    
    public class baseClass<T>
        where T:IIndexedProperty
    {   
		public T item;
        item.Getproperty(0); // access intValue
        item.Getproperty(1); // access stringValue
    }
