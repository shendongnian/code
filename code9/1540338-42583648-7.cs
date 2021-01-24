    StreamWriter SW = new StreamWriter(@"serialdata.txt");
    while(true)
    {
        string data_rx = myport.ReadLine();
        Console.WriteLine(data_rx);
        SW.WriteLine(data_rx);       // write to file
        if (data_rx == "exit")
        {
            break;      // break loop            
        }
    }
    SW.Close();
