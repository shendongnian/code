        public class CreateResourceViewModel
    {
     
       public Resource Resource {get;set;}
       public SelectList ResourceType {get;set;} //this will create the list of resourcetypes
       public int IdResourceType {get;set;} //this will be used to select the id of resourceType you are selecting.
    
    public CreateResourceViewModel (Resource resource,List<ResourceType>resourceType) //create a constructor 
    {
     this.Resource = resource;
    //here you will set the list as a new selectList, stating where the list will come from. the Id de valuevaluefield, and the name is the valuetextfield
    this.ResourceType= new SelectList(resourceType,"Id","Name");
    }
    
    public CreateResourceViewModel(){} //you need this second constructor
      
     }
