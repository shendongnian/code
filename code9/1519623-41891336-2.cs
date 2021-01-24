    string text = String.Empty;
    using (StreamReader stRead = new StreamReader(FileUpload1.PostedFile.InputStream))
    {
         int i = 0;
         //to write textfile content
         while (!stRead.EndOfStream)
         {
           text+=stRead.ReadLine()+Environment.NewLine;
           i++;
         }
         
     }
    
    multitxt.Text = text;
