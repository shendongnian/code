     public class DataObject<T>
     {
          private T _data;
          public DataObject(T data)
          {
              _data = data;
          }
          public T GetData()
          {
              return _data;
          }
     }
