     Image image = new Image();
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Open Image";
            op.Filter = "bmp files (*.bmp)|*.bmp";
    
            bool bNotBmp = true;
            while (op.ShowDialog() == true && bNotBmp == true)
            {
               FileInfo FileInf = new FileInfo(op.FileName);
               string ImgExtension = FileInf.Extension;
               if (FileInf.Extension.ToString().ToLower() != ".bmp")
               {
                   MessageBox.Show("Please upload only bmp file");
               }
               else
               {
                   bNotBmp = false;
               }
               
            }
    
            MessageBox.Show("Write image or operation cancelled.");
