    public class Page {
    
      private readonly Authorization _auth;
      private readonly IDictionary<string, Element> _elements = new Dictionary<string, Element>();
    
      public Element ElementOne => GetOrCreateElement();
      public Element ElementTwo => GetOrCreateElement();
      public Element ElementThree => GetOrCreateElement();
    
      public Page(Authorization auth) {
        _auth = auth;
      }
    
      private Element GetOrCreateElement([CallerMemberName] string name = null) {
        if(_elements.TryGetValue(name, out var returnElement)) 
          return returnElement;
        var element = new Element(_auth);
        _elements.Add(name, element);
        return element;
      }
    
    }
