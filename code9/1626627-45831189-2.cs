    public class ApiResponse 
        {
            public List<List<ElementList>> page { get; set; }    
        }
    interface ApiInterface
    {
    
        [Get("/magazine_pagevalue.php?mid=1&issueno=1")]
        Task<List<List<ElementList>>> GetElements();
    
    }
    var result = await api_interface.GetElements();
