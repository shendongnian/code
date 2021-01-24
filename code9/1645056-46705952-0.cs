                        try
                    {
                        //Find exes in dir and subdirs
                        String[] exes =
                        Directory.GetFiles("C:\\Temp", "*.EXE", SearchOption.AllDirectories)
                        .Select(fileName => Path.GetFileNameWithoutExtension(fileName))
                        .AsEnumerable()
                        .ToArray();
                        // kill the process if it is in the list 
                        var runningProceses = Process.GetProcesses();
                        for (int i = 0; i < runningProceses.Length; i++)
                        {
                         if (exes.Contains(runningProceses[i].ProcessName))
                         {
                          runningProceses[i].Kill(); 
                         }
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
