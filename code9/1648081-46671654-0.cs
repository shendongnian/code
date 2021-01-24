    var checksum = BitConverter.ToString(md5.ComputeHash(stream))                                               
                               .ToLower();
    System.Diagnostics.Debug.WriteLine(checksum);
    checksum = checksum.Replace("-", "");
    Console.Write(checksum);
    System.Diagnostics.Debugger.Break();
