                string tempStr;
                int size = serialPort1.BytesToRead;
                //runs as long as there are bytes in the serial buffer to be read,
                //you may need to change the way it runs to get all of your data depending upon
                //how the device is sending data to the serial port
                while (size != 0)
                {
                    //store incoming byte
                    int b1 = serialPort1.ReadByte();
                    //converts byte to character
                    char c = Convert.ToChar(b1);
                    //puts the character into a string                
                    tempStr = c.ToString();
                    //append it to Rx (output string)
                    Rx += tempStr;
                }
                //you'll may need to do some messing around with the character you use to split
                string[] results = Rx.Split(new Char[] {'\r' });
                
