    public class ProductImg
    {
      public string FileName  { set;get;}
      // or path as needed
    }
    public class EditProductImageVm
    {
       public string Title { set;get;}
       public IFormFile Image { set;get; }
       
       public IEnumerable<ProductImg> Images { set;get;}
    }
