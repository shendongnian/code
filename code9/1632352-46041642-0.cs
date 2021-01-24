    private void OpenApplication_Click(object sender, MouseButtonEventArgs e)
    {
            if (File.Exists(Globals.MyApplicationPath))
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = Globals.MyApplicationPath;
                Process.Start(start);
            }
            else
            {
                MessageBox.Show("Path is not correct.");
            }
    }
