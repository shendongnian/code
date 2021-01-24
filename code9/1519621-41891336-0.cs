    string text = String.Empty;
    using (StreamReader stRead = new StreamReader(FileUpload1.PostedFile.InputStream))
    {
         //to write textfile content
         while (!stRead.EndOfStream)
         {
           text+=stRead.ReadLine()+Environment.NewLine;
         }
     }
    
    multitxt.Text = text;
