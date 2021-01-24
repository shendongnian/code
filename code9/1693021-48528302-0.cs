        OpenFileDialog browse = new OpenFileDialog();
        browse.Filter = "Choose Questions to import(*.txt;)|*.txt";
        if (browse.ShowDialog() == DialogResult.OK)
        {
            string file_name = browse.FileName;
            using (System.IO.StreamReader txtReader = new System.IO.StreamReader(file_name))
            {
                // Do Your File Manipulation Here!
            }
        }
        
