    if (responsePost.IsSuccessStatusCode)
    {
         // Get the URI of the created resource.
         Uri returnUrl = responsePost.Headers.Location;
         Console.WriteLine(returnUrl);
    }
    else
    {
        string content = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);
    }
