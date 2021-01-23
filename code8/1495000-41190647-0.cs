         public void InsertPhotoToDb()
        {
            string filepath = "C:\\TFS\\Enterprise.jpg";
            byte[] Pic = File.ReadAllBytes(filepath);
            ArmadaDataContext oDc = new ArmadaDataContext();
            tblPictureTest otblPictureTest = new tblPictureTest();
            otblPictureTest.Id = Guid.NewGuid();
            otblPictureTest.FileName = "Enterprise";
            otblPictureTest.Photo = Pic;
            oDc.tblPictureTests.InsertOnSubmit(otblPictureTest);
            oDc.SubmitChanges();
            oDc = null;
        }   
        private void DisplayImageFromDb()
        {
            using (var oDc = new ArmadaDataContext())
            {
                var item = oDc
                    .tblPictureTests
                    .FirstOrDefault(x => x.FileName == "Enterprise"); // Retrieves using the filename
                //   If retrieving using the GUID, use the line below instead.
                //   .FirstOrDefault(x => x.Id == Guid.Parse("58b44a51-0627-43fe-9563-983aebdcda3a"));
                if (item == null)
                    throw new Exception("Image could not be found!");
                //Convert the byte[] to a BitmapImage
                BitmapImage img = new BitmapImage();
                MemoryStream ms = new MemoryStream(item.Photo.ToArray());
                img.BeginInit();
                img.StreamSource = ms;
                img.EndInit();
                //assign the image to the Source property of the Image box in the UI.
                imgPhoto.Source = img;
            }
        } 
