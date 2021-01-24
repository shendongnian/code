     public class CustomMessageHandler: DelegatingHandler
            {
           protected override Task<HttpResponseMessage> SendAsync(
                    HttpRequestMessage request, CancellationToken cancellationToken)
                {
                    var reasonInvalid = String.Empty;
    
                    var res= base.SendAsync(request, cancellationToken);
                    if (res.Result.StatusCode == HttpStatusCode.NotFound || res.Result.StatusCode == HttpStatusCode.MethodNotAllowed)
                    {
                        if(!res.Result.Headers.Contains("CustomHeaderforIntentional404"))
                        {
        
                             res.Result.StatusCode = HttpStatusCode.MethodNotAllowed;
                             res.Result.Content = new StringContent("Method doesn't support this method CUSTOM MESSAGE", System.Text.Encoding.UTF8, "text/html");
                             return res;
        
                        }
                    }
                    return res;
        
        
        
                    }
        }
