    var data = new Data();
    ...
    /* populate data somehow or other */
    ...
    MemoryStream str = new MemoryStream();  
    DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Person));
    ...
    ser.WriteObject(str, data);   
    ...
    /* read back that stream */
    str.Position = 0;  
    StreamReader sr = new StreamReader(st);  
    Console.WriteLine(sr.ReadToEnd());   /* or something else useful */
