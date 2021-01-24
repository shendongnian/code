     public class VehiDataCollectorController : DnnApiController
        {
            //URL to get the list of vehicles
                
            [HttpGet]
            //[DnnAuthorize()]
            //TODO: make it so we can call without ModuleId to get a list of vehicles
            [AllowAnonymous]
            public HttpResponseMessage GetVehicles()
            {
                try
                {
                    var mc = new ModuleController();
                    var mi = mc.GetModuleByDefinition(0, "VehiDataCollector"); 
    //TODO: assuming PortalId=0 if moduleid =0 
                    return GetVehicles(mi.ModuleID); 
                }
                catch (Exception exc)
                {
                    DnnLog.Error(exc); //todo: obsolete
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Module Not On A Page, or No Vehicles Exist"); //todo: probably should localize that?
                }
            }
        }
