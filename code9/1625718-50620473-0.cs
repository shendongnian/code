     public class RequestResultAJAX<T>
        {
            public bool success { get; set; }
            public T result { get; set; }
            public string error { get; set; }
            public string targetUrl { get; set; }
            public string unAuthorizedRequest { get; set; }
            public string __abp { get; set; }
        }
