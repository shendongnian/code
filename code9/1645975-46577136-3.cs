    public class ParentModel {
       public int ParentModelID {get; set;}
       ...other fields here
       public virtual ChildModel childModel {get; set;}
    }
    public class ChildModel{
       public int ParentModelID {get; set;}
       public int ChildModelID {get; set;}
       ...other fields and navigation properties here
    
       
       public virtual ParentModel parentModel {get; set;}
    }
