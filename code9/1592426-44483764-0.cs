    void GetAllPlayerWindows()
    {
            Process[] processes = Process.GetProcessesByName("gamex");
    
            foreach (Process p in processes)
            {
                IntPtr windowHandle = p.MainWindowHandle;
                  
                if (p.MainWindowTitle != "Login")
                {
                    // find if the handle already is in the list
                    if (lstPlayers.Find(i => i.Handle == windowHandle) == null)
                    { 
                       // it is not, add it 
                       Character player = new Character();
                       player.Handle = p.MainWindowHandle;
                       player.Name = p.MainWindowTitle;
                       lstPlayers.Items.Add(player);
                    }
                }
            }
    }
