    public class ListDict<K, T>:IList<T>
    {
    
       public Dictionary<K, T> dict = new Dictionary<K, T>();
       public List<T> list = new List<T>();
       Func<T,K> KeyFunc;
       
       // takes an Function that returns a key for T
       public ListDict(Func<T,K> keyfunc) 
       {
          KeyFunc = keyfunc;
       } 
       
       // called by the serializer
       public void Add(T value) 
       {
          Add( KeyFunc(value), value);
       }
       
       // fill both List and Dictionary
       public void Add(K key, T value) 
       {
          list.Add(value);
          dict.Add( key , value);
       }
       // left out other required methods from IList<T>
    }
