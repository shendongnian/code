    Task.Run(() => {
        try {
            IHadoop mycluster = Hadoop.Connect();
            string[] content = mycluster.StorageSystem.LsFiles("/");
            foreach (string s in content) {
                Console.WriteLine(s);
            }
        } catch (Exception exException) {
            ((Control)sender).Invoke(() => MessageBox.Show (exException.Message));
        }
    });
