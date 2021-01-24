     public static class CognitiveHelper
        {
            private const string UrlLuis = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/a267a797-9584-41a5-83f3-xxxxxxxxx?subscription-key=xxxxxxxxxxxxxxxxxxxxxxx&q=";
        public static async Task<LuisObjects> GetLuisAnswer(string textToEvaluate)
                {
                    if (string.IsNullOrWhiteSpace(textToEvaluate)) throw new ArgumentException("Null argument");
        
                    textToEvaluate= HttpUtility.UrlEncode(textToEvaluate);
                    var urlLuisWithRequest = UrlLuis + textToEvaluate;
        
                    var client = new HttpClient();
                    var body = new { };
        
                    var serializedBody = new JavaScriptSerializer().Serialize(body);
                    byte[] bodyByte = Encoding.UTF8.GetBytes(serializedBody );
        
                    using (var content = new ByteArrayContent(bodyByte))
                    {
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        var response= await client.GetAsync(urlLuisWithRequest );
                        var responseContent= await respuesta.Content.ReadAsStringAsync();
        
                        var javaScriptSerializer = new JavaScriptSerializer();
                        var resultTextAnalysis= javaScriptSerializer.Deserialize<LuisResult>(responseContent);
                        return new LuisObjects()
                        {
                            Entities= resultTextAnalysis.entities.ToList(),
                            TopScoringIntent = resultTextAnalysis.topScoringIntent
                        };
                    }
                }
    }
