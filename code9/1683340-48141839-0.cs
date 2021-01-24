    foreach (string path in filePaths)
            {
                int i = 0;
                filename.Add(Path.GetFileName(path));
                images.Images.Add(i.ToString(),Image.FromFile(path));
               ImageView.Items.Add(Path.GetFileNameWithoutExtension(path),i);
               ImageView.Items[ImageView.Count-1].ImageIndex = images.Images.Count-1
                richTextBox1.Text += path + Environment.NewLine;
                i++;
            }
