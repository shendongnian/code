    private void button10_DragEnter(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                {
                    e.Effect = DragDropEffects.All;
                }
            }
    
            private void button10_DragDrop(object sender, DragEventArgs e)
            {
                string draggedFileUrl = (string)e.Data.GetData(DataFormats.Html, false);
                string[] draggedFiles = (string[])e.Data.GetData(DataFormats.FileDrop, false);
    
                CatchFile(draggedFiles, draggedFileUrl);
            }
    
            private void CatchFile(string[] draggedFiles, string draggedFileUrl)
            {
                string directory = @"C:\test\";
    
                foreach (string file in draggedFiles)
                {
                    Directory.CreateDirectory(directory);
    
                    if (string.IsNullOrEmpty(draggedFileUrl))
                    {
                        if (!File.Exists(directory + Path.GetFileName(file))) File.Copy(file, directory + Path.GetFileName(file));
                        else
                        {
                            MessageBox.Show("File with that name already exists!");
                        }
                    }
                    else
                    {
                        string fileUrl = GetSourceImage(draggedFileUrl);
                        if (!File.Exists(directory + Path.GetFileName(fileUrl)))
                        {
                            using (var client = new WebClient())
                            {
                                client.DownloadFileAsync(new Uri(fileUrl), directory + Path.GetFileName(fileUrl));
                            }
                        }
                        else
                        {
                            MessageBox.Show("File with that name already exists!");
                        }
                    }
    
                    // Test check:
                    if (string.IsNullOrEmpty(draggedFileUrl)) MessageBox.Show("File dragged from hard drive.\n\nName:\n" + Path.GetFileName(file));
                    else MessageBox.Show("File dragged frow browser.\n\nName:\n" + Path.GetFileName(GetSourceImage(draggedFileUrl)));
                }
            }
    
            private string GetSourceImage(string str)
            {
                string finalString = string.Empty;
                string firstString = "src=\"";
                string lastString = "\"";
    
                int startPos = str.IndexOf(firstString) + firstString.Length;
                string modifiedString = str.Substring(startPos, str.Length - startPos);
                int endPos = modifiedString.IndexOf(lastString);
                finalString = modifiedString.Substring(0, endPos);
    
                return finalString;
            }
