    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    var storeField = typeof(HttpHeaders).GetField("headerStore", BindingFlags.Instance | BindingFlags.NonPublic);
    FieldInfo valueField = null;
    var store = (IEnumerable)storeField.GetValue(client.DefaultRequestHeaders);
    foreach (var item in store)
    {
        valueField = item.GetType().GetField("value", BindingFlags.Instance | BindingFlags.NonPublic);
        Console.WriteLine(valueField.GetValue(item));
    }
    for (int i = 0; i < 8; i++)
    {
        Task.Run(() =>
        {
            int iteration = 0;
            while (true)
            {
                iteration++;
                try
                {
                    foreach (var item in store)
                    {
                        var value = valueField.GetValue(item);
                        if (value == null)
                        {
                            Console.WriteLine("Iteration {0}, value is null", iteration);
                        }
                        break;
                    }
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                }
                catch (Exception) { }
            }
        });
    }
    Console.ReadLine();
