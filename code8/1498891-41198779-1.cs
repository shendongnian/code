    public class MapsController : Controller
    {
       // GET: MapsModel
       public ActionResult Index()
       {
    		var model = new MapsModel(
    				new[]
    				{
    					"Via Gavinana, 19, Roma",
    					"Val de Seine, 94600 Choisy le Roi",
    					"Street 21,Shuwaikh, Kuwait"
    				} 
    			);
    
          return View(model);
       }
    }
