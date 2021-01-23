    private void button1_Click(object sender, EventArgs e)
        {
            string basePath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string myDir = Path.Combine(basePath, "myFolder");
            if (!Directory.Exists(myDir))
            {
                Directory.CreateDirectory(myDir);
            }
            string myFile = Path.Combine(myDir, "textdoc.txt");
            using (FileStream fs = File.OpenWrite(myFile))
            {
                using (StreamWriter wrtr = new StreamWriter(fs, Encoding.UTF8))
                {
                    wrtr.WriteLine("This is my text");
                }
            }
            Process.Start("notepad.exe", myFile);
        }
