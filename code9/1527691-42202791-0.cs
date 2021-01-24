    public string Get_RegistryInfo(string VID, string PID)
            {
                try
                {
                    RegistryKey rk1 = Registry.LocalMachine;
                    // HKEY_LOCAL_MACHINE
                    RegistryKey rk2 = rk1.OpenSubKey("HARDWARE\\\\DEVICEMAP\\\\SERIALCOMM");
                    // HKEY_LOCAL_MACHINE\HARDWARE\\\\DEVICEMAP\\\\SERIALCOMM
                    VendorID = VID;
                    ProduktID = PID;
                    string pattern = string.Format("^VID_{0}.PID_{1}", VID, PID);
                    Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
                    string rk2_SubKeyNames = null;
                    foreach (string rk2_SubKeyNames_loopVariable in rk2.GetValueNames())
                    {
                        rk2_SubKeyNames = rk2_SubKeyNames_loopVariable;
                        if (rk2_SubKeyNames == "\\Device\\ProlificSerial0")
                        {
                            COM_Port = rk2.GetValue(rk2_SubKeyNames).ToString();                        
                        }
                    }
                    return COM_Port;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return COM_Port;
                }
    
            }
