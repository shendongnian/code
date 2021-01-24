    //Create the message we are going to send.
    string texttoSend = DateTime.Now.ToString();
    
    //Create a network stream to get all the data that com
    MemoryStream nwStream = new MemoryStream();
    
    //Convert out string message to a byteArray because we
    byte[] bytesToSend = Encoding.ASCII.GetBytes(texttoSen
    
    //Write out to the console what we are sending.
    Console.WriteLine("Sending: " + texttoSend);
    
    //Use the networkstream to send the byteArray we just 
    nwStream.Write(bytesToSend, 0, bytesToSend.Length);
    
    Encoding.Unicode.GetString(nwStream.ToArray()).Dump();
