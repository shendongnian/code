    public class PageSession
    {
      readonly BasePage _parent;
    
      public PageSession(BasePage parent)
      {
        _parent = parent;
      }
      
    
      public object this[string name]
      {
        get
        {
          return _parent.Session[GetFullKey(name)];  
        }
        set
        {
          _parent.Session[GetFullKey(name)] = value;
    
        }
      }
      public string GetFullKey(string name)
      {
        return _parent.PageInstanceUID + name;
      }
    }
