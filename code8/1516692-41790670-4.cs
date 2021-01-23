    public interface IDateTimeNowProvider
    {
        DateTime Now { get; }
    }
    public ProductController(IProductRepository productRepository,
                         IWebService webService, 
                         IDateTimeNowProvider dateTimeNowProvider)
    {
        _ProductRepository = productRepository;
        _WebService = webService;
        _dateTimeNowProvider = dateTimeNowProvider;
    }
