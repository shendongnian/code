    //mClient is my TCP connection
    StringBuilder returndata = new StringBuilder();
    Console.Write("This is what the host returned to you: ");
    // the StreamReader handles the encoding for you
    using(var sr = new StreamReader(mClient.GetStream(), Encoding.UTF8))
    {
        int value = sr.Read(); // read an int 
        while(value != -1)     // -1 means, we're done
        {
           var ch = (char) value; // cast the int to a char
           Console.Write(ch);     // print it
           returndata.Append(ch); // keep it
           value = sr.Read();     // read next char
        }
    }
    Console.WriteLine(" done.");
