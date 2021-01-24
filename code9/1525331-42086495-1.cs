    private void btnsource_Click(object sender, EventArgs e) {
      OpenFileDialog opf = new OpenFileDialog();
      opf.Multiselect = true;
      if (opf.ShowDialog() == DialogResult.OK) {
        string[] fnames = opf.FileNames;
        foreach (var item in fnames) {
          textBox1.Text = textBox1.Text + System.IO.Path.GetFileName(item) + Environment.NewLine;
        }
        BackupFiles(fnames);
      }
    }
    private void BackupFiles(string[] fnames) {
      string source;
      int i = 0;
      string destination = System.IO.Path.GetDirectoryName(fnames[0]);
      MessageBox.Show(destination);
      string fname = "";
      string FileToBackUp = "";
      foreach (var item in fnames) {
        source = item;
        fname = System.IO.Path.GetFileName(fnames[i]);
        FileToBackUp = destination + @"\" + fname + ".bac";
        File.Copy(source, FileToBackUp, true);
        i++;
      }
      MessageBox.Show("Successfull");
    }
