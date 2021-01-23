    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using Newtonsoft.Json;
    using System.Configuration; // get it from http://www.newtonsoft.com/json
    using Newtonsoft.Json.Linq;
    namespace AzureSearchTextAnalytics
    {
    /// <summary>
    /// This is a sample program that shows how to use the Azure ML Text Analytics app (https://datamarket.azure.com/dataset/amla/text-analytics)
    /// </summary>
    public class TextExtraction
    {
        static string azureMLTextAnalyticsKey = "<removed>";     // This key you will get when you have added TextAnalytics in Azure.
        private const string ServiceBaseUri = "https://westus.api.cognitive.microsoft.com/"; //This you will get when you have added TextAnalytics in Azure
        public static async Task<KeyPhraseResult> ProcessText()
        {
            string filetext = "Build great search experiences for your web and mobile apps. " +
                "Many applications use search as the primary interaction pattern for their users. When it comes to search, user expectations are high. They expect great relevance, suggestions, near-instantaneous responses, multiple languages, faceting, and more. Azure Search makes it easy to add powerful and sophisticated search capabilities to your website or application. The integrated Microsoft natural language stack, also used in Bing and Office, has been improved over 16 years of development. Quickly and easily tune search results, and construct rich, fine-tuned ranking models to tie search results to business goals. Reliable throughput and storage provide fast search indexing and querying to support time-sensitive search scenarios. " +
                "Reduce complexity with a fully managed service. " +
                "Azure Search removes the complexity of setting up and managing your own search index. This fully managed service helps you avoid the hassle of dealing with index corruption, service availability, scaling, and service updates. Create multiple indexes with no incremental cost per index. Easily scale up or down as the traffic and data volume of your application changes.";
            KeyPhraseResult keyPhraseResult = new KeyPhraseResult();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(ServiceBaseUri);
                // Request headers.
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", azureMLTextAnalyticsKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                byte[] byteData = Encoding.UTF8.GetBytes("{\"documents\":[" +
                   "{\"id\":\"1\",\"text\":\"" + filetext + "\"},]}");
                // Detect key phrases:
                var keyPhrasesRequest = "text/analytics/v2.0/keyPhrases";
                // get key phrases
                using (var getcontent = new ByteArrayContent(byteData))
                {
                    getcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var response = await httpClient.PostAsync(keyPhrasesRequest, getcontent);
                    Task<string> contentTask = response.Content.ReadAsStringAsync();
                    string content = contentTask.Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Call to get key phrases failed with HTTP status code: " +
                                            response.StatusCode + " and contents: " + content);
                    }
                    var result = JsonConvert.DeserializeObject<RootObject>(content);
                    keyPhraseResult.KeyPhrases = result.documents[0].keyPhrases;
                }
            }
            return keyPhraseResult;
        }
    }
    public class Documents
    {
        public List<string> keyPhrases { get; set; }
        public string id { get; set; }
    }
    public class RootObject
    {
        public List<Documents> documents { get; set; }
        public List<object> errors { get; set; }
    }
    /// <summary>
    /// Class to hold result of Key Phrases call
    /// </summary>
    public class KeyPhraseResult
    {
        public List<string> KeyPhrases { get; set; }
    }
    }
