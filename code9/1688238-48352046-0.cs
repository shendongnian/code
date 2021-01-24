    private void SendMessage()
    {
        //---data to send to the server---
        string textToSend = DateTime.Now.ToString();
    
        NetworkStream nwStream = Client.GetStream();
        //---send the text---
        Console.WriteLine("Sending : " + textToSend);
        using (StreamWriter nwsWriter = new StreamWriter(nwStream, Encoding.ASCII))
        {
            nwsWriter.Write(textToSend);
        }
        //---read back the text---
        using (StreamReader reader = new StreamReader(nwStream, Encoding.ASCII))
        {
            string responseText = reader.ReadToEnd();
            Debug.Print("Received : " + responseText);
        }
        Client.Close();
    }
