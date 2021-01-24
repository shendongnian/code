    public class LogsController : ApiController
    {
    	public HttpResponseMessage Get()
    	{
    		var machineList = db.Machines.ToList();
    		var sb = new StringBuilder();
    		
    		foreach (var mk in machineList)
    		{
    			
    			var list = (from o in db.Logs
    						where o.Machine == mk.Machine1 && o.sDate == DateTime.Today
    						select o).ToList();
    			var fileName = mk.Machine1;
    	sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", "\"Ac-No\"", "\"Name\"", "\"sTime\"", "\"Verify Mode\"", "\"Machine\"", "\"Exception\"", "\"checktype\"", "\"sensorid\"", "\"workcode\"", "\"sDate\"", Environment.NewLine);
    			foreach (var item in list)
    			{
    				sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", "\"" + item.Ac_No + "\"", "\"" + item.Name + "\"", "\"" + item.sTime + "\"", "\"" + item.VerifyMode + "\"", "\"" + item.Machine + "\"", "\"" + item.Exception + "\"", "\"" + item.CheckType + "\"", "\"" + item.SensorId + "\"", "\"" + item.WorkCode + "\"", "\"" + item.sDate.Value.ToShortDateString() + "\"", Environment.NewLine);
    			}
    		}
    		
    		HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
    
    		var stream = new MemoryStream(Encoding.ASCII.GetBytes(sb.ToString()));
    		
    		result.Content = new StreamContent(stream);
    		result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
    		result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
    		result.Content.Headers.ContentDisposition.FileName = filename;
    
    		return result;
    	}
    
    }
