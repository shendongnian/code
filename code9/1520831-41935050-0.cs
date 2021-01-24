    _additionalControl = new AutoResetEvent(false);
    var networkStream = _clientSocket.GetStream();
    networkStream.Read(bytesFrom, 0, Convert.ToInt32(_clientSocket.ReceiveBufferSize));
    _additionalControl.Set();
    _mainthreadControl.WaitOne(Timeout.Infinite);
    try
    {
      //some code
      _mainthreadControl.Reset();
      _additionalControl.WaitOne(Timeout.Infinite);
       //some code that uses the same socket as above
     
      _mainthreadControl.Set();
    }
    catch (Exception ex)
    {
      //ignored
    }
