    using System.Net.Http;
    using System.Net.Http.Headers;
    HttpContent _Body = new StringContent(request);
    // and add the header to this object instance
    _Body.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data; boundary=----WebKitFormBoundarygWsJMIUcbjwBPfeL");
    // synchronous request without the need for .ContinueWith() or await
    HttpClient client = new HttpClient();
    var response = client.PostAsync(new Uri(youruri), _Body).GetAwaiter().GetResult();
