    private Task<string> GetData(string dataToPost)
    {
        var url = "some URL";
        var resultSource = new TaskCompletionSource<string>();
        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadStringCompleted += (s, e) => {
                Console.WriteLine("Result is here");
                Console.WriteLine(e.Result);
                // this will complete the task
                resultSource.SetResult(e.Result);
            };
            client.UploadStringAsync(new System.Uri(url), "POST", dataToPost);
        }
        return resultSource.Task;
    }
