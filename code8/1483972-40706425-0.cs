    private static void Downloadfile()
    {
        //Download 5000 file
        Sftp ftp = new Sftp(dtr["FTP_SERVER"].ToString(), dtr["FTP_USER_ID"].ToString(), dtr["FTP_PASSWORD"].ToString());
        ftp.Connect<ftp://ftp.connect/>();
        System.IO.Directory.CreateDirectory(@localDestnDir);
        ArrayList list;
        list = ftp.GetFileList(remotepath<ftp://ftp.getfilelist(remotepath/>);
        //GExport_EI_DN_G_6542_StarMetroDeiraHotel&Apartment_10.235.155.37_20161120003108.xml.gz
        Parallel.ForEach(list, item => 
            {
                if (item.StartsWith("GExport_") &&(!item.ToUpper().Contains("DUM")))
                {
                    path = item;
                    //path = "GExport_EI_DN_G_6542_StarMetroDeiraHotel&Apartment_10.235.155.37_20161120003108.xml.gz";
                    ftp.Get(dtr["REMOTE_FILE_PATH"].ToString() + path, @localDestnDir + "\\" + dtr["SOURCE_PATH"].ToString());
                    download_location_hw = dtr["LOCAL_FILE_PATH"].ToString();
                    //  ExtractZipfiles(download_location_hw + "//" + path, dtr["REMOTE_FILE_PATH"].ToString(), dtr["FTP_SERVER"].ToString(), dtr["FTP_USER_ID"].ToString(), dtr["TECH_CODE"].ToString(), dtr["VENDOR_CODE"].ToString());
                }
                //extract file by using Ionic.zip 
                 Extractfile(item);   <= Extractfile works on a single file now
                //then process file
                ProcessFile(item);    <= ProcessFile works on a single file now
            });
            ftp.Close();
          
    }
  
