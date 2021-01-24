    public class ProductImg
    {
      public string Title { set;get;}
      public string FileName  { set;get;}
      // or path as needed
    }
    public class EditProductImageVm
    {
       public string Title { set;get;} //for the new item
       public IFormFile Image { set;get; }  //for the new item
       
       public IEnumerable<ProductImg> Images { set;get;}
    }
