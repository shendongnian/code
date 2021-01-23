    var samples = new List<Sample>();
    samples.Add(new Sample()
    {
        Data = new List<List<double>>()
        {
            new List<double> { 0, 6.48 },
            new List<double> { 1, 6.43 }
            //...other values
        },
        Label = "Port-1"
    };
    string json = JsonConvert.SerializeObject(samples);
