    public int main()
    {
        var fileText = File.ReadAllLines(@"file.txt");
        
        var taskList = new List<Task>();
        foreach (var line in fileText)
        {
            taskList.Add(Task.Factory.StartNew(HandlerMethod, line));
            //you can control the amount of produced task if you want:
            //if(taskList.Count > 20)
            //{
            //    Task.WaitAll(taskList.ToArray());
            //    taskList.Clear();
            //}
        }
        Task.WaitAll(taskList.ToArray()); //this line may not work as I expected.
        //file.Close();
    }
    public void HandlerMethod(object obj)
    {
        var line = (string)obj;
        using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
        {
            client.BaseAddress = new Uri("https://www.website.com/");
            HttpResponseMessage response = client.GetAsync("index?userGetLevel=" + line).Result;
            response.EnsureSuccessStatusCode();
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic json = JObject.Parse(result);
            string level = json.data.level;
            if (level == "null")
            {
                Console.WriteLine("{0}: User does not exist.", line);
            }
            else
            {
                Console.WriteLine("{0}: User level is {1}.", line, level);
                using (StreamWriter sw = File.AppendText(levels.txt))
                {
                    sw.WriteLine("{0} : {1}", line, level);
                }
            }
        }
    }
