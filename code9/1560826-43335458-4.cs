    [Route("/getconsignments/{ConsignmentNumber}", "POST")]
    public class GetConsignments : List<string>, IReturn<PublishManifestResponse> 
    {
        public string ConsignmentNumber { get; set; }
    }
