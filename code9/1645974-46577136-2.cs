    public class ParentModel {
       [Key]
       public int ParentModelID {get; set;}
       ...other fields here
       public virtual ChildModel ChildModel {get; set;}
    }
    public class ChildModel{
       [Key]
       public int ChildModelID {get; set;}
       ...other fields and navigation properties here
    
       public int ParentModelID {get; set;}
       public virtual ParentModel ParentModel {get; set;}
    }
