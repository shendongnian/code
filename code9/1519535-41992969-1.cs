    [WebMethod]
    public void sendSMSMessage_inHouse(String Recipients, String MessageBody)
    {
        String sanitizedRecipient = Recipients.Replace(" ", "");
        var RecipientList = Recipients.Split(',').ToList();
        String sanitizedMessage = MessageBody.Replace(@"\n", Environment.NewLine);
        SerialPort SP = new SerialPort();
        SP.PortName = "COM3";
        SP.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
        SP.Open();
        // Initally set property to the "condtion" value to allow first message to be run without the datarecieved response from the serial port
        spReadMsg = "+CMGS:";
        // Set executionTime inital value for comparison
        executionTime = DateTime.Now;
        foreach (String Recipient in RecipientList)
        {
            // Infinite Loop listens to the response from the serial port
            while (true)
            {
                // If the +CMGS: response was recieved continue with the next message
                // Use Contains comparison for substring check since some of the +CMGS: responses 
                // contain carriage return texts along with the repsonse
                // Then empty the spReadMsg property to avoid the loop from prematurely 
                //sending the next message when the latest serial port response has not yet been 
                //updated from the '+CMGS:' response
                if (!string.IsNullOrEmpty(spReadMsg) && spReadMsg.Contains("+CMGS:"))
                {
                    spReadMsg = string.Empty;
                    break;
                }
                // If takes longer than 30 seconds to get the response since the last sent 
                //message - break.
                if (DateTime.Now > executionTime.AddSeconds(30))
                {
                    break;
                }
            }
            
            // Once the while loop breaks proceed with sending the next message.            
            String formattedRecipientNo = Char.ConvertFromUtf32(34) + Recipient + Char.ConvertFromUtf32(34);
            SP.Write("AT+CMGF=1" + Char.ConvertFromUtf32(13));
                //Thread.Sleep(800);
            SP.Write("AT+CMGS=" + formattedRecipientNo + Char.ConvertFromUtf32(13));
                //Thread.Sleep(800);
            SP.Write(sanitizedMessage + Char.ConvertFromUtf32(26) + Char.ConvertFromUtf32(13));
                //Thread.Sleep(1000);
                //Thread.Sleep(2000);
            // Get the Datetime when the current message was sent for comparison in
            // the next while loop
            executionTime = DateTime.Now;
        }
        SP.Close();
    }
