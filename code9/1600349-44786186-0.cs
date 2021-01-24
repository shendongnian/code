    public struct DirtyableProperty<T>
    {
       private T _value;
    
       public bool IsDirty { get; private set; }
    
       public T Value 
       { 
           get { return _value; }
           set
           {
                IsDirty |= !EqualityComparer<T>.Equals(value, _value);
                _value = value;
           }
       }
       
       public void LoadValue(T savedValue) { _value = savedValue; }
    
       public void MarkSaved() { IsDirty = false; }
    }
