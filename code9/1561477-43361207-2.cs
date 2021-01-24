    class BaseBusinessLogic
    {
	    private DBconnector _connector;
	
	    public void initConnector( DBConnector iConnector)
	    {
	    	this._connector =  iConnector;
	    }
	
        public void commonMethod1() 
        {
        }
        public void commonMethod2() 
        {
        }
        public Object GetXData()
       { 
            
                ...//setting
		    	_connector.SetQuery("..."); // Query to get 'X' Data
                return _connector.GetExcetue();
        }
    }
    Class BusinessLogicM1 : BaseBusinessLogic
    {
          public void M1LogicMethod()
          {
              // Fetch DataList from DBConnector
	    	  _connector.SetQuery(".....");
	    	  Object obj = _connector.GetExecute();
		  
		      Object xData = GetXData();
		  
		      // use obj and xData Object to build BusinessLogicM1
          }
    }
        
