    public class RequestFilterHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Task<HttpResponseMessage> responseTask;
            if (IsPostOrPutCall(request))
            {
               responseTask = base.SendAsync(request, cancellationToken).ContinueWith(task => task.Result);
            }
            else
            {                        
                responseTask = new Task<HttpResponseMessage>(() => new HttpResponseMessage(HttpStatusCode.Unauthorized));
                responseTask.Start()
            }
        }
        private bool IsAuthorizedPostOrPutCall(HttpRequestMessage request)
        {
          var referrerList = //Assumption:Predefined list you get through a service 
          return referrerList.Contains(request.Headers.Referrer) && ( request.Method == HttpMethod.Post || request.Method == HttpMethod.Put);
        }
    }
    
