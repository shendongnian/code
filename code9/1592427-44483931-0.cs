    void GetAllPlayerWindows()
    {
        Process[] processes = Process.GetProcessesByName("gamex");
        foreach (Process p in processes)
        {
            IntPtr windowHandle = p.MainWindowHandle;
            if (p.MainWindowTitle != "Login" && !ContainsHandle(p))//<--Made a little function
            {
                Character player = new Character();
                player.Handle = p.MainWindowHandle;
                player.Name = p.MainWindowTitle;
                lstPlayers.Items.Add(player);
            }
        }
    }
    bool ContainsHandle(Process p)
        {
            
            for (int i = 0; i < lstPlayers.Items.Count; i++)
            {
                Character player = lstPlayers.Items[i] as Character;
                if (player.Handle == p.MainWindowHandle)
                    return true;
            }
            return false;
        }
