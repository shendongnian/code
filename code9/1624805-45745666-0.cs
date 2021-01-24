    public class Page {
    
      private readonly Authorization _auth;
      private readonly IDictionary<Element> _elements = new Dictionary<Element>();
    
      public Element ElementOne => GetOrCreateElement();
      public Element ElementTwo => GetOrCreateElement();
      public Element ElementThree => GetOrCreateElement();
    
      public Page(Authorization auth) {
        _auth = auth;
      }
    
      public Element GetOrCreateElement([CallerMemberName] string name = null) {
        var element = new Element(_auth);
        _elements.Add(name, element);
        return element;
      }
    
    }
