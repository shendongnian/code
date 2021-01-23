            bool isFileOpen(string file)
              {    
                string windowTitle = "";
                
    
                Process[] myProcesses = Process.GetProcesses();
    
                foreach (Process P in myProcesses)
                {
                    if (P.MainWindowTitle.Length > 1)
                    {
                        windowTitle = P.MainWindowTitle;
                        if (windowTitle.Contains(file) == true)
                        {
                            return true;                        
                        }                    
                    }
                    
                }
                return false;
    
            }
   
    
