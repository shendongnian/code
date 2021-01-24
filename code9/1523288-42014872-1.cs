           var serializer = new JavaScriptSerializer();
           var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(postData);
           var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
           // pass the data to the api
           System.Net.Http.HttpResponseMessage response = await client.PostAsync(baseUrl, stringContent);
