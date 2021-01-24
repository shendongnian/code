        public void saveCanvas()
        {
            string subpath = Directory.GetCurrentDirectory();
            SaveFileDialog saveFileDialog12 = new SaveFileDialog();
            saveFileDialog12.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png File|*.png";
            saveFileDialog12.Title = "Save an Image File";
            saveFileDialog12.InitialDirectory = subpath;
            saveFileDialog12.ShowDialog();
            if (saveFileDialog12.FileName == "") return;
            subpath = saveFileDialog12.FileName.Substring(0, saveFileDialog12.FileName.Length - saveFileDialog12.SafeFileName.Length);
            
            string extension = saveFileDialog12.FileName.Remove(subpath.IndexOf(subpath), subpath.Length);
            string[] allStr = extension.Split('.');
            string fileName = allStr[0];
            string folderName = fileName + "_" + allStr[1];
            folderName = subpath + folderName;
            Directory.CreateDirectory(folderName);
            DirectoryInfo dInfo = new DirectoryInfo(folderName);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            string saveFile = folderName + "\\" + fileName + "_";
            for (int i = 0; i < listCanvas.Count; i++)
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)listCanvas[i].Width, (int)listCanvas[i].Height, 96d, 96d, PixelFormats.Default);
                rtb.Render(listCanvas[i]);
                DrawingVisual dvInk = new DrawingVisual();
                DrawingContext dcInk = dvInk.RenderOpen();
                dcInk.DrawRectangle(listCanvas[i].Background, null, new Rect(0d, 0d, listCanvas[i].Width, listCanvas[i].Height));
                foreach (System.Windows.Ink.Stroke stroke in listCanvas[i].Strokes)
                {
                    stroke.Draw(dcInk);
                }
                dcInk.Close();
                FileStream fs = File.Open(saveFile + (i + 1).ToString() + "." + allStr[1], FileMode.OpenOrCreate);//save bitmap to file
                System.Windows.Media.Imaging.JpegBitmapEncoder encoder1 = new JpegBitmapEncoder();
                encoder1.Frames.Add(BitmapFrame.Create(rtb));
                encoder1.Save(fs);
                fs.Close();
            }
        }
