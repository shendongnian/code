      var dest = @"C:\location";
        var source = @"http://server1/sites/PrDB/";
        var fileName = "sql.txt";
        
        using (SPSite site = new SPSite(source))
        {
            using (SPWeb web = site.OpenWeb())
            {
                    SPFile file = web.GetFile(web.Url +"/Shared%20Documents/" + fileName);// here, this added web url
        if(file.Exists) 
            {
                    byte[] b = file.OpenBinary();
                    FileStream fs = new FileStream(dest + "\\" + file.Name, FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(b);
                    bw.Close();
            }
        }
     }
