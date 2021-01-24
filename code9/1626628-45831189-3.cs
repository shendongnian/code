    public class ApiResponse 
        {
            public List<List<ElementList>> page { get; set; }    
        }
    interface ApiInterface
    {
    
        [Get("/magazine_pagevalue.php?mid=1&issueno=1")]
        Task<List<List<ElementList>>> GetElements();
    
    }
    var resultTask = api_interface.UserInitiated.GetElements();
    var result = await Policy
    						.Handle<Exception>()
    						.RetryAsync(retryCount: 1)
    						.ExecuteAsync(async () => await resultTask);
