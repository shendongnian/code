    using System.Net.Http;
    using System.Net.Http.Headers;
    using (var httpClient = new HttpClient()) 
    { 
        var httpContent = new StringContent(request); 
        httpContent.Headers.Clear(); 
        httpContent.Headers.Add("Content-Type", "multipart/form-data; boundary=----WebKitFormBoundarygWsJMIUcbjwBPfeL"); 
        var response = await httpClient.PostAsync(requestUri, httpContent); 
    } 
