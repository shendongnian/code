          string filePath = "Data\\postbody.txt";
                string url = "https://outlook.office365.com/EWS/Exchange.asmx";
    
                Uri requestUri = new Uri(url); //replace your Url  
    
                string contents = await ReadFileContentsAsync(filePath);
                string search_str = txtSearch.Text;
    
                Debug.WriteLine("Search query:" + search_str);
                contents = contents.Replace("%SEARCH%", search_str);
    
                Windows.Web.Http.Filters.HttpBaseProtocolFilter hbpf = new Windows.Web.Http.Filters.HttpBaseProtocolFilter();
                Windows.Security.Credentials.PasswordCredential pcred = new Windows.Security.Credentials.PasswordCredential(url, "username@acme.com", "password");
                hbpf.ServerCredential = pcred;
                 
                HttpClient request = new HttpClient(hbpf);
    
                Windows.Web.Http.HttpRequestMessage hreqm = new Windows.Web.Http.HttpRequestMessage(Windows.Web.Http.HttpMethod.Post, new Uri(url));
                Windows.Web.Http.HttpStringContent hstr = new Windows.Web.Http.HttpStringContent(contents, Windows.Storage.Streams.UnicodeEncoding.Utf8, "text/xml");
                hreqm.Content = hstr;
    
                // consume the HttpResponseMessage and the remainder of your code logic from here.
    
    
                try
                {
                    Windows.Web.Http.HttpResponseMessage hrespm = await request.SendRequestAsync(hreqm);
    
                    Debug.WriteLine(hrespm.Content);
                    String respcontent = await hrespm.Content.ReadAsStringAsync();
    
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                    Debug.WriteLine(e);
                }
