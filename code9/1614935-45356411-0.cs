    public void GetData(string dataToPost)
    {
        var url = "some URL";
        var url2 = "some other URL";
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
                
            var task1 = client.UploadStringTaskAsync(new System.Uri(url), "POST", dataToPost);
            var task2 = client.UploadStringTaskAsync(new System.Uri(url2), "POST", dataToPost);
            var results = Task.WhenAll(task1, task2).Result;
            foreach (var result in results)
            {
                Console.WriteLine("Result is here");
                Console.WriteLine(result);
            }
        }
    }
