        public void FileDropped(object sender, DragEventArgs e)
        {
            TextBox txtFileName = (TextBox)sender;
            DDQEnums.TranTypes tag = (DDQEnums.TranTypes)txtFileName.Tag;
            string fileName = string.Empty;
            new Thread(() => fileName = FileDroppedBackground(tag, e)).Start();
            txtFileName.Text = fileName;
        }
