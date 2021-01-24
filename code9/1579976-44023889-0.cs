    DialogResult openFile = openFileDialog1.ShowDialog();
            if (openFile == DialogResult.OK)
            {
                Functions func = new Functions();
                string file = openFileDialog1.FileName;
                string content = File.ReadAllText(file);
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text File|*.txt";
                sfd.FileName = "New Text Doucment";
                sfd.Title = "Save As Text File";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    content= content.Remove(content.LastIndexOf(","));
                    string path = sfd.FileName;
                    StreamWriter bw = new StreamWriter(File.Create(path));
                    bw.WriteLine(content);
                    bw.Close();
                    File.WriteAllLines(path, File.ReadAllLines(path).Select(x => string.Format("{0},", x)));
                    
                }
            }
