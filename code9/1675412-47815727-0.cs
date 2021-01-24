    var bytes = Encoding.UTF8.GetBytes("masaväg");
    foreach(var enc in Encoding.GetEncodings())
    {
        try
        {
            if(enc.GetEncoding().GetString(bytes) == "masavÃ¤g")
            {
                Console.WriteLine($"{enc.CodePage} {enc.DisplayName}");
            }
        } catch { }
    }
