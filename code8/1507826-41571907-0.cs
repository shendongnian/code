    var recordClass = cb.CreateRecordClass();
    List<FieldInfo> fields = recordClass.GetFields().ToList();
    FileHelperAsyncEngine fhe = new FileHelperAsyncEngine(recordClass);
    using (fhe.BeginReadStream(file))
    {
        foreach (var record in fhe)
        {
            IDictionary<string, object> values = fields.ToDictionary(x => x.Name, x => x.GetValue(record));
            values.Add("SourceSystem", "messagesource");
            values.Add("SourceType", "messagetype");
            string json = JsonConvert.SerializeObject(values, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
