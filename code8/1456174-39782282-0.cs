    Image Dosya;
    private void btnopen_Click(object sender, EventArgs e)
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Jpg|*.Jpg";
                if (of.ShowDialog()==DialogResult.OK)
                {
    
                    Dosya = Image.FromFile(of.FileName);
                    pictureBox1.Image = Dosya;
                }
            }
    
     private void btnSave_Click(object sender, EventArgs e)
            {
            SaveFileDialog sd = new SaveFileDialog();
            sd.InitialDirectory = "C:\\Users\\sonyy\\Videos\\";
            sd.Title = "Save Files";
            sd.CheckFileExists = true;
            sd.CheckPathExists = true;
            sd.DefaultExt = "jpg";
            sd.Filter = "JPG(*.jpg)|*.jpg|All files (*.*)|*.*";
            sd.FilterIndex = 1;
            sd.RestoreDirectory = false;
    
                string dosyaadi = sd.InitialDirectory;
                string date = Convert.ToString(DateTime.Today.ToShortDateString());
                sd.FileName = date;
                Dosya.Save(sd.InitialDirectory+date+"."+sd.DefaultExt);
