    if (response.IsSuccessStatusCode)
    {
        var rootObject = response.Content.ReadAsAsync<RootObject>().Result;
        foreach (var item in rootObject.Data)
        {
            Console.WriteLine(item.Email);
        }
    }
