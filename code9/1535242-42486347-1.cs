    ZPLString = @"^XA^MMP^PW300^LS0^LT0^FT10,60^APN,30,30^FH\^FDSAMPLE TEXT^FS^XZ";
    // Open connection
    System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
    client.Connect("10.10.5.85", 9100);
    // Write ZPL String to connection
    System.IO.StreamWriter writer = new System.IO.StreamWriter(client.GetStream());
    writer.Write(ZPLString);
    writer.Flush();
    // Close Connection
    writer.Close();
    client.Close();
