        Please try this , i am using this in my project , its working for me
        
        
        
         if (file.ContentType.Contains("image"))
                    {
                        string theFileName = Path.GetFileName(file.FileName);
                        byte[] thePictureAsBytes = new byte[file.ContentLength];
                        using (BinaryReader theReader = new BinaryReader(file.InputStream))
                        {
                            thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                        }
                        string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                        
                    }
        
        
        "thePictureDataAsString " variable got Base64 string 
    
    
    .........................................................................
    
    
    i am getting file like this in my project
    
     public ActionResult SaveMake(string inputMakeName, HttpPostedFileBase file)
            {
                MakeModel objMakeModel = new MakeModel();
                if (file.ContentType.Contains("image"))
                {
                    string theFileName = Path.GetFileName(file.FileName);
                    byte[] thePictureAsBytes = new byte[file.ContentLength];
                    using (BinaryReader theReader = new BinaryReader(file.InputStream))
                    {
                        thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                    }
                    string thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);
                    objMakeModel.ImageBase64 = thePictureDataAsString;
                    objMakeModel.Make1 = inputMakeName;
                }
    
                string response = _apiHelper.ConvertIntoReturnStringPostRequest<MakeModel>(objMakeModel, "api/Transaction/SaveMakes/");
              //  string response = _apiHelper.SaveMake(objMakeModel, "api/Transaction/SaveMakes/");
                return RedirectToAction("AddVehicleMaintenance");
            }
