    public class ParentModel {
       [Key]
       public int ParentModelID {get; set;}
       ...other fields here
    
       public ChildModel ChildModel {get; set;}
    }
    public class ChildModel{
       [Key]
       public int ChildModelID {get; set;}
       ...other fields and navigation properties here
    
       [ForeignKey("ParentModel")]
       public int ParentModelID {get; set;}
       public ParentModel ParentModel {get; set;}
    }
