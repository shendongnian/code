    System.IO.FileStream fs =
               new System.IO.FileStream("D:" + fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
    
            fs.Write(data, 0, data.Length);
            fs.Close();
