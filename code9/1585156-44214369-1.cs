        void Copy(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);
            foreach (var file in Directory.GetFiles(sourceDir))
                File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)));
            foreach (var directory in Directory.GetDirectories(sourceDir))
                Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Copy("E:\autotransfer", "E:\autotransferbackup");
            Copy("E:\autotransfer", "E:\autotransferbackupcp");
        }
