    void Main()
    {
       
        Curl.GlobalInit(3);
        var downloadFileUrl ="http://i.stack.imgur.com/LkiIZ.png"; 
    
        using(var easy = new Easy())
        using(FileStream fs = new FileStream(@"something2.png", FileMode.Create))
        {   
            // the delegate points to our method with the same signature
            Easy.WriteFunction wd = OnWriteData; 
            easy.SetOpt(CURLoption.CURLOPT_URL, downloadFileUrl); 
            // we do a GET
            easy.SetOpt(CURLoption.CURLOPT_HTTPGET, 1); 
            // set our delegate
            easy.SetOpt(CURLoption.CURLOPT_WRITEFUNCTION, wd);
            // which object we want in extraData
            easy.SetOpt(CURLoption.CURLOPT_WRITEDATA, fs);
        
            // let's go (notice that this are enums that get returned)
            if (easy.Perform() == CURLcode.CURLE_OK)
            {
              // we can be sure the file is written correctly
              "Success".Dump();
            }
            else 
            {
              "Error".Dump();
            }
        }
    }
    
    System.Int32 OnWriteData(byte[] buf, Int32 size, Int32 nmemb, Object extraData)
    {
        // cast  extraData to the filestream
        var fs = (FileStream) extraData;
        fs.Write(buf, 0, buf.Length);
        return size * nmemb;
    } //OnWriteData
