        using MarketplaceWebServiceProducts.Model;
        using System;
        using System.IO;
        using MWSClientCsRuntime;
    
        namespace AmazonMWS.Tests
        {
        public class MyMWSMock : MarketplaceWebServiceProducts.MarketplaceWebServiceProducts
        {
    
            // Definitions of most methods removed for brevity. They all match the pattern of ListMatchingProductsResponse.
    
            public ListMatchingProductsResponse ListMatchingProducts(ListMatchingProductsRequest request)
            {
                return newResponse<ListMatchingProductsResponse>();
            }
    
            private T newResponse<T>() where T : IMWSResponse
            {
                FileStream xmlIn = File.Open("D:\\MyTestDataFolder\\Test1.xml", FileMode.Open);
                try
                {
                    StreamReader xmlInReader = new StreamReader(xmlIn);
                    string xmlStr = xmlInReader.ReadToEnd();
    
                    MwsXmlReader reader = new MwsXmlReader(xmlStr);
                    T obj = (T)Activator.CreateInstance(typeof(T));
                    obj.ReadFragmentFrom(reader);
                    obj.ResponseHeaderMetadata = new ResponseHeaderMetadata("mockRequestId", "A,B,C", "mockTimestamp", 0d, 0d, new DateTime());
                    return obj;
                }
                catch (Exception e)
                {
                    throw MwsUtil.Wrap(e);
                }
                finally
                {
                    if (xmlIn != null) { xmlIn.Close(); }
                }
            }
        }
    }
