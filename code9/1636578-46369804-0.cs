     byte[] test = (Byte[])reader[0];
        Console.WriteLine("============================RAW===========================================");                            
        string text = System.Text.UnicodeEncoding.UTF8.GetString(test);
        Console.WriteLine(text);
        Console.WriteLine("============================UNPACKED======================================");
        var json = MessagePackSerializer.ToJson(test);
