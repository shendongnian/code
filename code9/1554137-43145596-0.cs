    public void mailmerge()
    {
        string base64String;
        using (Image image = Image.FromFile(MyDir + @"image.png"))
        {
            using (MemoryStream m = new MemoryStream())
            {
                image.Save(m, image.RawFormat);
                byte[] imageBytes = m.ToArray();
    
                // Convert byte[] to Base64 String
                base64String = Convert.ToBase64String(imageBytes);
            }
        }
    
        DataTable dt = new DataTable();
        dt.Columns.Add("ImageData", typeof(string));
    
        DataRow row1 = dt.NewRow();
        row1["ImageData"] = base64String;
        dt.Rows.Add(row1);
    
        Document doc = new Document(MyDir + "in.docx");
        doc.MailMerge.FieldMergingCallback = new HandleMergeImageFieldFromBlob();
        doc.MailMerge.Execute(dt);
        doc.Save(MyDir + "Out.docx");
    }
    
    public class HandleMergeImageFieldFromBlob : IFieldMergingCallback
    {
        void IFieldMergingCallback.FieldMerging(FieldMergingArgs args)
        {
            // Do nothing.
        }
    
        /// <summary>
        /// This is called when mail merge engine encounters Image:XXX merge field in the document.
        /// You have a chance to return an Image object, file name or a stream that contains the image.
        /// </summary>
        void IFieldMergingCallback.ImageFieldMerging(ImageFieldMergingArgs e)
        {
            var imageStream = new MemoryStream((byte[])Convert.FromBase64String(e.FieldValue.ToString()));
                   
            // Now the mail merge engine will retrieve the image from the stream.
            e.ImageStream = imageStream;
        }
    }
