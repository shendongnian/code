    public class ParentModel 
    {
       public int ParentModelID {get; set;}
       public ChildModel ChildModel {get; set;}
    }
    public class ChildModel
    {
       [ForeignKey("ParentModel")]
       public int ChildModelID {get; set;}
       public ParentModel ParentModel {get; set;}
    }
    var parent = new ParentModel();
    dbContext.Set<ParentModel>().Add( parent );
    dbContext.SaveChanges();
    var child = new ChildModel()
    {
         ChildModelID = parent.ParentModelID
    };
    dbContext.Set<ChildModel>().Add( child );
    dbContext.SaveChanges();
