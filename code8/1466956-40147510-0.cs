    class DirtyClass
    {
      protected bool IsDirty { get; set;}
      protected void ChangeProperty<T>(ref T backing, T Value)
      { 
          if(!backing.Equals(value))
          {
               backing = value;
               IsDirty = true;
          }
      }
    }
