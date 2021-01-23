    void Main()
    {
    		
    	var serviceAppointment = new Entity("serviceappointment")
    	{
    		Attributes = new AttributeCollection() { { "resources", GetResources() } }
    	};
    	
    	var sa = serviceAppointment.GetAttributeValue<EntityCollection>("resources");
    	
    	Console.WriteLine(sa.Entities.Count);
    }
    
    public EntityCollection GetResources()
    {
    	var entityList = new List<Entity>();
    	entityList.Add(new Entity("resource")
    	{
    		Attributes = new AttributeCollection() { { "name", "Truck" }}
    	});
    	
    	entityList.Add(new Entity("resource")
    	{
    		Attributes = new AttributeCollection() { { "name", "Tool" } }
    	});
    	
    	return new EntityCollection(entityList);
    
    }
