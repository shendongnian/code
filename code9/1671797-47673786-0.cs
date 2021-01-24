    public class ChildObject
    {
      public ChildObject(ParentObject aParent)
      {
        parent = aParent
      }
      public ParentObject parent { get; private set; }
      public int id {get;set;}
      public string child_object_name {get;set;}
    }
