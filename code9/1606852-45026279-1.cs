    HttpFileCollection hfc = Request.Files;
    if (hfc != null)
    {
        string cekDir = string.Format("{0}\\{1}", ConfigurationManager.AppSettings["docLoc"], id_hazard_report);
        string PicDir;
        if (Directory.Exists(cekDir)) //check Folder avlalible or not
        {
            PicDir = cekDir;
        }
        else
        {
            DirectoryInfo di = Directory.CreateDirectory(cekDir); // create Folder
            PicDir = cekDir;
        }
        string fullname;
        string filename;
        //FileUpload FileUpload1 = (FileUpload)FormView1.FindControl("FileUpload1");
        for (int i = 0; i < hfc.Count; i++)
        {
            HttpPostedFile hpf = hfc[i];
            if (hpf.ContentLength > 0)
            {
                ///full path name to check exist or not
                fullname = string.Format("{0}\\{1}", PicDir, Path.GetFileName(hpf.FileName.Replace(" ", "_")));
                // get the file name here.
                string fileExt = Path.GetExtension(FileUpload1.FileName); //Get The File Extension 
                   
                if (FileExt == (".jpg") || fileExt == (".gif") || fileExt == (".bmp") || fileExt == (".png") || fileExt == (".jpeg"))
                {
                    if (hpf.ContentLength.Length > 200000)
                    {
                        ClientScript.RegisterStartupScript(Type.GetType("System.String"), "messagebox", "<script type=\"text/javascript\">alert('File Tidak boleh lebih dari 200 kb');</script>");
                        continue; // break will exit the loop, use continue to go to the next file
                    }
                    if (File.Exists(fullname))
                    {
                        string f = Path.GetFileNameWithoutExtension(hpf.FileName.Replace(" ", "_"));
                        string timeStamp = DateTime.Now.ToString("yymdHm"); // this could fail, be more specific with your timestamp;
                        filename = f + timeStamp + fileExt;
                        // this will not work correctly if more than one "." in the file name
                        //string[] a = new string[1];
                        //a = f.Split('.');
                        //filename = string.Format("{0}_{1}.{2}", a.GetValue(0), DateTime.Now.ToString("yymdHm"), a.GetValue(1));
                    }
                    else
                    {
                        filename = Path.GetFileName(hpf.FileName.Replace(" ", "_")).ToString();
                    }
                    ///full path name to store in database with new filename
                    //string[] aa = new string[1];
                    //filename = string.Format("{0}_{1}.{2}", aa.GetValue(0), DateTime.Now.ToString("yymdHm"), aa.GetValue(1));
                    fullname = string.Format("{0}\\{1}", PicDir, filename);
                    hpf.SaveAs(fullname); //save as
                    InsertHazardDoc(id_hazard_report, filename);
                }
                else
                {
                    FileUpload1.Focus();
                    ClientScript.RegisterStartupScript(Type.GetType("System.String"), "messagebox", "<script type=\"text/javascript\">alert('File Bukan Format Gambar');</script>");
                    continue;// break will exit the loop, use continue to go to the next file
                }
            }
            //}
        }
    }
