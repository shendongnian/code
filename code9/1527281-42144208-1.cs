    //mClient is my TCP connection
    StringBuilder returndata = new StringBuilder();
    Console.Write("This is what the host returned to you: ");
    // the StreamReader handles the encoding for you
    using(var sr = new StreamReader(mClient.GetStream(), Encoding.UTF8))
    {
        int value = sr.Read();
        while(value != -1)
        {
           var ch = (char) value;
           Console.Write(ch);
           returndata.Append(ch);
           value = sr.Read(); // read next char
        }
    }
    Console.WriteLine(" done.");
