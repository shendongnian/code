    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Google.Apis.Auth.OAuth2;
    using Newtonsoft.Json;
    
    namespace prediction_client
    {
        class Person
        {
            public int age { get; set; }
            public String workclass { get; set; }
            public String education { get; set; }
            public int education_num { get; set; }
            public string marital_status { get; set; }
            public string occupation { get; set; }
            public string relationship { get; set; }
            public string race { get; set; }
            public string gender { get; set; }
            public int capital_gain { get; set; }
            public int capital_loss { get; set; }
            public int hours_per_week { get; set; }
            public string native_country { get; set; }
        }
    
        class Prediction
        {
            public List<Double> probabilities { get; set; }
            public List<Double> logits { get; set; }
            public Int32 classes { get; set; }
            public List<Double> logistic { get; set; }
    
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }
    
        class MainClass
        {
            static PredictClient client = new PredictClient();
            static String project = "MY_PROJECT";
            static String model = "census";  // Whatever you deployed your model as
    
            public static void Main(string[] args)
            {
                RunAsync().Wait();
            }
    
            static async Task RunAsync()
            {
                try
                {
                    Person person = new Person
                    {
                        age = 25,
                        workclass = " Private",
                        education = " 11th",
                        education_num = 7,
                        marital_status = " Never - married",
                        occupation = " Machine - op - inspct",
                        relationship = " Own - child",
                        race = " Black",
                        gender = " Male",
                        capital_gain = 0,
                        capital_loss = 0,
                        hours_per_week = 40,
                        native_country = " United - Stats"
                    };
                    var instances = new List<Person> { person };
    
                    List<Prediction> predictions = await client.Predict<Person, Prediction>(project, model, instances);
                    Console.WriteLine(String.Join("\n", predictions));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    
        class PredictClient {
    
            private HttpClient client;
    
    		public PredictClient() 
            {
                this.client = new HttpClient();
    			client.BaseAddress = new Uri("https://ml.googleapis.com/v1/");
    			client.DefaultRequestHeaders.Accept.Clear();
    			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    		}        
    
    		public async Task<List<O>> Predict<I, O>(String project, String model, List<I> instances, String version = null)
            {
    			var version_suffix = version == null ? "" : $"/version/{version}";
    			var model_uri = $"projects/{project}/models/{model}{version_suffix}";
    			var predict_uri = $"{model_uri}:predict";
    
    			GoogleCredential credential = await GoogleCredential.GetApplicationDefaultAsync();
                var bearer_token = await credential.UnderlyingCredential.GetAccessTokenForRequestAsync();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer_token);
    
                var request = new { instances = instances };
                var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
    
                var responseMessage = await client.PostAsync(predict_uri, content);
                responseMessage.EnsureSuccessStatusCode();
    
                var responseBody = await responseMessage.Content.ReadAsStringAsync();
                dynamic response = JsonConvert.DeserializeObject(responseBody);
    
                return response.predictions.ToObject<List<O>>();
            }
        }
    }
