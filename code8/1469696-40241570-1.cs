            var _notepadProcess = System.Diagnostics.Process.GetProcesses().Where(x => x.ProcessName.ToLower().Contains("notepad")).DefaultIfEmpty(null).FirstOrDefault();
            if ( _notepadProcess != null )
            {
                var _windowHandle = FindWindow(null, "Page Setup");
                var _parent = GetParent(_windowHandle);
                if ( _parent == _notepadProcess.MainWindowHandle )
                {
                    //We found our Page Setup window, and it belongs to Notepad.exe - yay!
                }
            }
