    int i = 0;
           
    foreach (string path in filePaths)
        {
            filename.Add(Path.GetFileName(path));
            images.Images.Add(i.ToString(),Image.FromFile(path));
           ImageView.Items.Add(Path.GetFileNameWithoutExtension(path),i);
            richTextBox1.Text += path + Environment.NewLine;
            i++;
        }
