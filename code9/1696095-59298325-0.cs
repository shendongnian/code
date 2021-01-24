           rasDialFileName = Path.Combine(WinDir, "rasdial.exe");
            try
            {
                string args = $"{connectionName} {userName} {passWord}";
                ProcessStartInfo myProcess = new ProcessStartInfo(rasDialFileName, args);
                myProcess.CreateNoWindow = true;
                myProcess.UseShellExecute = false;
                Process.Start(myProcess);
            }
            catch (Exception Ex)
            {
                Debug.Assert(false, Ex.ToString());
            }
