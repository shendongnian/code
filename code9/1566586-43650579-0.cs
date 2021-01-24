        private void UserControl1_DragEnter(object sender, DragEventArgs e)
        {
            // if you want to read the message data as a string use this:
            if (e.Data.GetDataPresent(DataFormats.UnicodeText))
            {
                e.Effect = DragDropEffects.Copy;
            }
            // if you want to read the whole .msg file use this:
            if (e.Data.GetDataPresent("FileGroupDescriptorW") && 
                e.Data.GetDataPresent("FileContents"))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
            // to read basic info about the mail use this:
            var text = e.Data.GetData(DataFormats.UnicodeText).ToString();
            var message = text.Split(new string[] { "\r\n" }, StringSplitOptions.None)[1];
            var parts = message.Split('\t');
            var from = parts[0]; // Email From
            var subject = parts[1]; // Email Subject
            var time = parts[2]; // Email Time
            // to get the .msg file contents use this:
            // credits to "George Vovos", http://stackoverflow.com/a/43577490/1093508
            var outlookFile = e.Data.GetData("FileGroupDescriptor", true) as MemoryStream;
            if (outlookFile != null)
            {
                var dataObject = new iwantedue.Windows.Forms.OutlookDataObject(e.Data);
                var filenames = (string[])dataObject.GetData("FileGroupDescriptorW");
                var filestreams = (MemoryStream[])dataObject.GetData("FileContents");
                for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
                {
                    string filename = filenames[fileIndex];
                    MemoryStream filestream = filestreams[fileIndex];
                    // do whatever you want with filestream, e.g. save to a file:
                    string path = Path.GetTempPath() + filename;
                    using (var outputStream = File.Create(path))
                    {
                        filestream.WriteTo(outputStream);
                    }
                }
            }
        }
