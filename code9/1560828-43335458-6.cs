    [Route("/getconsignments", "POST")]
    public class GetConsignments : List<string>, IReturn<PublishManifestResponse> 
    {
        public string[] ConsignmentNumbers { get; set; }
    }
