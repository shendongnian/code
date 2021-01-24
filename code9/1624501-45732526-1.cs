    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            if (IsFire)
            {
                
                    int dataLength = _serialPort.BytesToRead;
                    byte[] data = new byte[dataLength];
                    int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                    if (nbrDataRead == 0)
                        return;
                    string str = System.Text.Encoding.UTF8.GetString(data);
    
                    double number;
                    bool success = false;
                    if (Double.TryParse(str, out number))
                    {
                        success = true;
                    }
                    else
                    {
                        var match = Regex.Match( str, @"\d+\.\d+");
                        if( match.Success )
                        {
                            success = Double.TryParse(match.Value, out number);
                        }
                    }
                
                    if( success )
                    {
                        if(txtBCGGrassWeight.InvokeRequired )
                        {
                         txtBCGGrassWeight.BeginInvoke(()=> {
                            txtBCGGrassWeight.Text = string.Format("{0:0.000}", number);
                         });
                        }
                        else
                        {
                         txtBCGGrassWeight.Text = string.Format("{0:0.000}", number);
                        }
                  }
            }
        }
