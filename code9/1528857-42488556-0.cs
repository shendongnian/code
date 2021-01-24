     using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Ports"))
             {
                 foreach (string name in ndpKey.GetValueNames())
                 {
                     if (name.Remove(name.IndexOf(":")).ToLower().Equals(ComName.ToLower()))
                     {
                         var tempArray = ndpKey.GetValue(name).ToString().Split(',');
                         int speed = 0;
                         char parity = ' ';
                         int dataBits = 0;
                         Decimal stopBit = 0;
                         string parityS ="";
                         ComSettings.Add("Name", ComName);
                         if ((Int32.TryParse(tempArray[0], out speed)) && (Int32.TryParse(tempArray[2], out dataBits)) && (Decimal.TryParse(tempArray[3].Replace(".", ","), out stopBit)) && (Char.TryParse(tempArray[1], out parity)))
                         {
                          
                             ComSettings.Add("Speed", speed);
                             ComSettings.Add("DataBits", dataBits);
                             ComSettings.Add("StopBits", stopBit);
                             switch (parity)
                             {
                                 case 'e':
                                     parityS = "Even";
                                     break;
                                 case 'n':
                                     parityS = "None";
                                     break;
                                 case 'o':
                                     parityS = "Odd";
                                     break;
                                 case 'm':
                                     parityS = "Mark";
                                     break;
                                 case 's':
                                     parityS = "Space";
                                     break;
                             }
                             ComSettings.Add("Parity", parityS);
                         }
                         break;
                     }
                 }
             }
