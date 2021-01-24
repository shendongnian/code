     ProcessStartInfo info = new ProcessStartInfo("notepad.exe");
                info.WindowStyle = ProcessWindowStyle.Maximized;
                Process process = new Process();
                process.StartInfo = info;
                process.Start();
                Thread.Sleep(2000);
                bool res = process.CloseMainWindow(); // InvalidOperationException -> already exited
                process.Close();
