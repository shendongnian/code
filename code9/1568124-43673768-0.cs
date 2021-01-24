            try
            {
                Process[] processes = Process.GetProcessesByName("php");
                foreach (var process in processes)
                {
                    MessageBox.Show(process.ToString());
                    process.Kill();
                }
            }
            catch
            {
                MessageBox.Show("No");
            }
