    protected void Page_Load(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.GetAsync("http://localhost:14388/WebForm2.aspx").ContinueWith(
                 getTask =>
                 {
                     if (getTask.IsCanceled)
                     {
                         Console.WriteLine("Request was canceled");
                     }
                     else if (getTask.IsFaulted)
                     {
                         Console.WriteLine("Request failed: {0}", getTask.Exception);
                     }
                     else
                     {
                         HttpResponseMessage response = getTask.Result;
                         
                         string _message = response.Content.ReadAsStringAsync()
                                               .Result
                                               .Replace("\\", "")
                                               .Trim(new char[1] { '"' });
                     }
                 });
        }
