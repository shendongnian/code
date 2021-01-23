    public class Catalog {
    ...
    public virtual ICollection<Item> Items {get;set;}
    public virtual ICollection<Subscriber> Subscribers {get;set;}
    }
    
    public class Item {
    ...
    public virtual ICollection<Catalog> Catalogs {get;set;}
    }
    
    public class Subscriber {
    ...
    public virtual ICollection<Catalog> Catalogs {get;set;}
    }
