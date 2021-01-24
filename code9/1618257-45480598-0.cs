    [RoutePrefix("api/V2.0/monitors")] 
    public sealed class MonitorsController : ApiController
    {
        /* 
            /monitors/get?heartbeat=foo
        */
     
         [Route("GetHeartbeat")]
        public JsonResult GetHeartbeatStatusV2(string heartbeat)
        {
            var x = new JsonResult {Data = "heartbeat v2"};
            return x;
        }
        /* 
            /monitors/get?alert=foo 
        */
          [Route(" GetAlertStatus")]
        public JsonResult GetAlertStatus(string alert)
        {
            var x = new JsonResult {Data = "alerts"};
            return x;
        }
    
    }
