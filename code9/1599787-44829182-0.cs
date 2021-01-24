    var local = DateTime.Now;
    var utc = DateTime.SpecifyKind(local, DateTimeKind.Utc);
            
    var _requestContentLocal = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(local);
    var _requestContentUTC = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(utc);
    _requestContentLocal	"\"2017-06-29T18:19:32.6704837+03:00\""	
	_requestContentUTC	"\"2017-06-29T18:19:32.6704837Z\""	
     
