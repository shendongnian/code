    public class A
    {
      private string name;      
      public string Name
      {
        get { return this.name; }
        set 
        {
          if (value != this.name)
          {
            this.name = value;        
            this.RaiseChanged();
          }
        }
      }
      // ... more properties here ...
      
      public event EventHandler Changed;
      
      private void RaiseChanged()
      {
        this.Changed?.Invoke(this, EventArgs.Empty);
      }
    }
    public class B
    {
      public A PropertyA { get; set; }
    }
