     public static class Utils
        {
            public static IFlurlClient GetBaseUrlForOperations(string resource)
            {
                var _apiUrl = "https://api.mobile.azure.com/v0.1/apps/";
    
                var url = _apiUrl
                    .AppendPathSegment("Red-Space")
                    .AppendPathSegment("HD")
                    .AppendPathSegment("push")
                    .AppendPathSegment("notifications")
                    .WithHeader("Accept", "application/json")
                    .WithHeader("X-API-Token", "myapitocken");
    
    
                return url;
            }
    
            public static async Task Invia()
            {
    
                FlurlClient _client;
    
                PushMessage pushMessage = new PushMessage();
    
                pushMessage.notification_content = new NotificationContent();
    
    
     
    
                try
                {
                    var flurClient = Utils.GetBaseUrlForOperations("risorsa");
                    // News news = (News)contentService.GetById(node.Id);
    
                    //pushMessage.notification_target.type = "";
                    pushMessage.notification_content.name = "A2";
                    // pushMessage.notification_content.title = node.GetValue("TitoloNews").ToString();
                    pushMessage.notification_content.title = "Titolo";
                    pushMessage.notification_content.body = "Contenuto";
     
    
                 
    
                    var jobInJson = JsonConvert.SerializeObject(pushMessage);
                    var json = new StringContent(jobInJson, Encoding.UTF8);
                    json.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
    
     
    
                    dynamic data2 = await flurClient.PostAsync(json).ReceiveJson();
    
                     
    
                     var expandoDic = (IDictionary<string, object>)data2;
    
                     var name = expandoDic["notification_id"];
    
                    Console.WriteLine(name);
    
    
    
                }
                catch (FlurlHttpTimeoutException ex)
                {
                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + ex);
    
                }
                catch (FlurlHttpException ex)
                {
                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + ex);
                    if (ex.Call.Response != null)
    
                        Console.WriteLine("Failed with response code " + ex.Call.Response.StatusCode);
                    else
    
                        Console.WriteLine("Totally failed before getting a response! " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType + " " + ex);
    
                };
            }
    
    
    
        }
    
        public class NotificationTarget
            {
                public string type { get; set; }
            }
    
            public class CustomData
            {
            }
    
            public class NotificationContent
            {
                public string name { get; set; }
                public string title { get; set; }
                public string body { get; set; }
                public CustomData custom_data { get; set; }
            }
    
            public class PushMessage
            {
                public NotificationTarget notification_target { get; set; }
                public NotificationContent notification_content { get; set; }
            }
