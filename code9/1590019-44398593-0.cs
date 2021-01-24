    byte[] byteArray = File.ReadAllBytes("D:\Document.docx");    
    using (var stream = new MemoryStream())
        {
            stream.Write(byteArray, 0, (int)byteArray.Length);
            using (var document = WordprocessingDocument.Open(stream, true))
            {
               //Here fill document
            }
            // And save file
            File.WriteAllBytes("D:\NewDocument.docx", stream.ToArray()); 
        }
