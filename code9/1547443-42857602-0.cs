            var formParams = new Dictionary<string, string>(){
                ["content"] = "Hello World~"
            };
            var stringFormParams = new Func<IDictionary<string,string>,string>((dic) => {
                string result = "";
                foreach(var param in dic) {
                    if (result.Length > 0) { result += "&"; }
                    result += param.Key + "=" + WebUtility.UrlEncode(param.Value);
                }   
                return result;             
            }).Invoke(formParams); 
            var stringContent = new StringContent(stringFormParams, Encoding.UTF8, "application/x-www-form-urlencoded");
            Console.WriteLine(stringContent.ReadAsStringAsync().Result);
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync(url, stringContent);
