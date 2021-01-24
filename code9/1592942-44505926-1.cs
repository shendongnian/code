    sc.Connect(distantEndPoint);
    while (!sc.Connected)
       Thread.Sleep(1000);
    byte[] buffer = Utility.ConvertMessage("Hell world !");
    sc.Send(buffer, buffer.Length, SocketFlags.None);
    sc.Close();
