        var dest = @"C:\location";
        var source = @"http://server1/sites/PrDB/";
        using (SPSite site = new SPSite(source))
             {
                  using (SPWeb web = site.OpenWeb())
                  {
                        SPFolder myfolder = web.GetFolder("Shared Documents");
                        SPFile file = myfolder.Files[fileName];
                        byte[] b = file.OpenBinary();
                        string fullPath =destination + "\\" + file.Name;
                        FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.ReadWrite);
                        BinaryWriter bw = new BinaryWriter(fs);
                        bw.Write(b);
                        bw.Close();
                        }
                    }
