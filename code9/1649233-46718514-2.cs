    public class Wish
    {
       public int Id { set;get;}
       public ICollection<Image> Images { set;get;} 
    }
    public class Image
    {
       public int Id { set;get;}
       public int WishId { set;get;}
       public virtual Image Image{ set;get;} 
    }
