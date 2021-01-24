    string filePath = @"C:\Test\test.csv";
    string csvLine = "value1; value2; value3" + Environment.NewLine;
    byte[] csvLineBytes = Encoding.Default.GetBytes(csvLine);
    using (MemoryStream ms = new MemoryStream())
    {
          ms.Write(csvLineBytes , 0, csvLineBytes.Length);
          using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
           {                        
               byte[] bytes = new byte[file.Length];
               file.Read(bytes, 0, (int)file.Length);
               ms.Write(bytes, 0, (int)file.Length);                    
            }
    
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
    }
