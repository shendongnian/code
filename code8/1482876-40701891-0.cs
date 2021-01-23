    [HttpPost]
    public IHttpActionResult Create(List<ServiceModel> serviceModelList) {
        //work involving model
    }
    
    
    public class ServiceModel
    {
    	public int CenterMapNbr { get; set; }
    	public int Qty { get; set; }
    }
