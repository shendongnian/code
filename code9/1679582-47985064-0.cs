    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    
    namespace Foo
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void PhpHashTest()
            {
    
                string IPN_SECRET = "I-am-the-secret";
    
                //Mocking some HTTP POSTed data
                var someFormUrlEncodedData = "order_id=1234&product_title=Hello%20World&product_id=Sku123";
    
                //Mocking json_encode($_POST)
                var data = HttpUtility.ParseQueryString(someFormUrlEncodedData);
                var dictionary = data.AllKeys.ToDictionary(key => key, key => data[key]);
    
                //{"order_id":"1234","product_title":"Hello World","product_id":"Sku123"}
                var json = JsonConvert.SerializeObject(dictionary);          
                
                byte[] bytes;
                using (var hmac512 = new HMACSHA512(Encoding.ASCII.GetBytes(IPN_SECRET)))
                {
                    bytes = hmac512.ComputeHash(Encoding.ASCII.GetBytes(json));                        
                }
    
                //will contain lower-case hex like Php hash_hmac
                var hash = new StringBuilder();
                Array.ForEach(bytes, b => hash.Append(b.ToString("x2")));           
    
                //Assert that Php output exactly matches
                Assert.IsTrue(string.Equals("340c0049bde54aa0d34ea180f8e015c96edfc4d4a6cbd7f139d80df9669237c3d564f10366f3549a61871779c2a20d2512c364ee56af18a25f70b89bd8b07421", hash.ToString(), StringComparison.Ordinal));
                Console.WriteLine(hash);
            }
        }
    }
