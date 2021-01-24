    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    
    class Test
    {
        public static void Do()
        {
            var result = GetGameData("da10b68dea6a42d58ea8fea66a57b886").Result;
    
            //TODO parse json here. For example, see http://stackoverflow.com/questions/6620165/how-can-i-parse-json-with-c
            Console.WriteLine(result);
        }
    
        private static async Task<string> GetGameData(string id)
        {
            var url = "http://hivemc.com/json/userprofile/" + id;
    
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
    
                HttpResponseMessage response = await client.GetAsync(url);
    
                if (response.IsSuccessStatusCode)
                {
                    string strResult = await response.Content.ReadAsStringAsync();
    
                    return strResult;
                }
                else
                {
                    return null;
                }
            }
        }
    }
