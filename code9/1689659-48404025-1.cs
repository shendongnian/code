    CustomerViewModel vm = new CustomerViewModel();
    //...
    using (MemoryStream ms = new MemoryStream())
    {
        DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(CustomerViewModel));
        ser.WriteObject(ms, vm);
        File.WriteAllText("save.txt", Encoding.UTF8.GetString(ms.ToArray()));
    }
