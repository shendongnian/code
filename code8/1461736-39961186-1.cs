    public struct CompatibilityParam
    {
        public int MediaId;
        public int ProductsTypId;
        public string id;
        public string PreviousURL;
        public HttpRequestBase Request;
        public int? Width;
        public int? Height;
        public int? CampaignID;
    }
    public static void GetCompatibility(CompatibilityParam paramters)
    {
        Console.WriteLine("  MediaId = {0}", paramters.MediaId);
        Console.WriteLine("  ProductsTypId= {0}", paramters.ProductsTypId);
        Console.WriteLine("  PreviousURL= {0}", paramters.PreviousURL);
        Console.WriteLine("  Request= {0}", paramters.Request);
        Console.WriteLine("  Width= {0}", paramters.Width);
        Console.WriteLine("  Height= {0}", paramters.Height);
        Console.WriteLine("  CampaignID= {0}", paramters.CampaignID);
    }
    //...
    CompatibilityParam paramters = new CompatibilityParam
    {
        MediaId = 1,
        ProductsTypId = 1,
        PreviousURL = "http://xxx",
        Request = null,
        Width = 123,
        Height = 123,
    };
    GetCompatibility(paramters);
    //...
