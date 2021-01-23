    public class ListAndCreateVm
    {
      [Required]
      public string NewComment { set;get;}
      
      public Guid BookId { set;get;}
      
      public List<CommentVm> Comments { set;get;}
    }
    public class CommentVm
    {
      public string Comment { set;get;}
      public string Author { set;get;}
    }
