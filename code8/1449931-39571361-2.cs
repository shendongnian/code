    public function void catagory_click()
    {
       Getservice("Cat");
    }
    public function void location_click()
    {
       Getservice("Loc");
    }
    public function void username_click()
    {
       Getservice("Usr");
    }
    
    function void Getservice(string _selButton)
    {
      switch(_selButton)
		{
			case 'Cat': 
			// call catagory webservice
			break;
			case 'Loc': 
			// call Location webservice
			break;
			case 'Usr': 
			// call Username webservice
			break;
			default : 
			//call default service
		}
    }   
    
   
   
