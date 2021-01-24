    public class PostParameters
    {
        public string PartitionBuildDate {get;set;}
    }
    [HttpPost]
    public IHttpActionResult BuildPartitions([FromBody]PostParameters parameters)
    {
        //you can access parameters.PartitionBuildDate
    }
