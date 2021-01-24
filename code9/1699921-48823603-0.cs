    [Route("/api/{ApiEndpoint}/1", "POST")]
    public ApiRequest1 : ApiRequestBase<Endpoint1> {}
    [Route("/api/{ApiEndpoint}/2", "POST")]
    public ApiRequest2 : ApiRequestBase<Endpoint1> {}
    public abstract class ApiRequestBase<T> : IReturn<ApiResponse<T>>
    {
        public int OrderId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string ApiEndpoint { get; set; }
    }
