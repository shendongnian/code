                private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
                {   
                    SetText(serialPort1.ReadExisting());
                }
                private void SetText(string text)
                {
                    if (Output.InvokeRequired)
                    {	
                     	SetTextCallback d = new SetTextCallback(SetText);
                    	this.Invoke(d, new object[] { text });
                    }
                    else
                    {
                  	    Output.Text = text;
                    }
                }
