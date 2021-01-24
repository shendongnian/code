    private void UploadButton_Click(object sender, EventArgs e)
    {
    	string safeName = "";
    	string pathName = PictureHelper.PathReturner(ref safeName);
    	PictureViewModel vm = new PictureViewModel();
    	if (pathName != "")
    	{
    		safeName = safeName.Encryptor();
    
    		FileStream fs = new FileStream(pathName, FileMode.Open, FileAccess.Read);
    		byte[] data = new byte[fs.Length];
    		
    		
    		fs.Read(data, 0, Convert.ToInt32(fs.Length));
    		fs.Close();
    
    		PicNameLabel.Text = safeName;
    		vm.Entity.Name = safeName; //this is the byte[]
    
    		Bitmap toBeConverted = PictureHelper.ByteToBitmap(data); //convert the picture before sending to the db
    
    		vm.Entity.Photo = PictureHelper.BitmapToByte(toBeConverted);
    		vm.Entity.Path = pathName;
    
    		CandidatePictureBox.Image = toBeConverted;
    
    		pictureVm.Insert(vm.Entity);
    
    	}
    }
