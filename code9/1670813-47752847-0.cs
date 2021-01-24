    public string Start_Appl()
        {
            try
            {
                
                string myAppPath = "C:\\Windows\\System32\\notepad.exe";
              
                RegistryKey key = Registry.ClassesRoot.OpenSubKey("myAppa");  //open myApp protocol's subkey
                if (key == null)  //if the protocol is not registered yet...we register it
                {
                    key = Registry.ClassesRoot.CreateSubKey("myAppa");
                    key.SetValue(string.Empty, "URL: myApp Protocol");
                    key.SetValue("URL Protocol", string.Empty);
                    key = key.CreateSubKey(@"shell\open\command");
                    key.SetValue(string.Empty, myAppPath + " " + "%1");
                    
                }
                key.Close();
            }
            catch (Exception e) {
                return e.Message.ToString();
            }
           
            
            return "ok";
        }
