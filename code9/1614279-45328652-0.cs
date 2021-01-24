            public void CreateSubnestImageFromNestingReport(string picturePath,string  docPath)
        {
            var fileDir = Path.GetDirectoryName(picturePath);
            Directory.CreateDirectory(fileDir);
       
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            var document = DocumentModel.Load(docPath, LoadOptions.DocDefault);
            var pict = document.GetChildElements(true).Single(el => el.ElementType == ElementType.Picture) as Picture;
            File.WriteAllBytes(picturePath, pict.PictureStream.ToArray());            
        }
