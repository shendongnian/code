    string json = "[{ \"Demand\": 4422.45, \"Supply\": 17660, \"Date\": \"/Date(1236504600000)/\", \"DateString\": \"3 PM\" },  { \"Demand\": 4622.88, \"Supply\": 7794, \"Date\": \"/Date(1236522600000)/\", \"DateString\": \"8 PM\" }, { \"Demand\": 545.65, \"Supply\": 2767, \"Date\": \"/Date(1236583800000)/\", \"DateString\": \"1 PM\" }, { \"Demand\": 0, \"Supply\": 1, \"Date\": \"/Date(1236587400000)/\", \"DateString\": \"2 PM\" }]";
    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<MyModel>));
    using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(json)))
    {
        List<MyModel> models = (List<MyModel>)serializer.ReadObject(stream);
        foreach (MyModel model in models)
        {
            // do something with the model here
            Console.WriteLine(model.Date);
        }
    }
