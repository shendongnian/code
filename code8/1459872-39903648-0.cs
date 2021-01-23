    private async void btnCovert_Click(object sender, EventArgs e)
    {
        //get file
        string blfrpath = txtPath.Text;
        byte[] b = new byte[108];
        //ASCIIEncoding ascii = new ASCIIEncoding();
        string blfObjstr;
        long filesize;
        long numObjs;
        int i;
    
        using (FileStream fs = File.Open(blfrpath, FileMode.Open))
        {
            filesize = fs.Length;
            numObjs = filesize / 56;
            i = 0;
            while (await Task<int>.Factory.FromAsync(fs.BeginRead, fs.EndRead, b, 0, b.Length, null) > 0)
            {
                blfObjstr = Encoding.ASCII.GetString(b);
                lstData.Items.Add(blfObjstr);
                prbConvert.Value = (i/(int)numObjs)*100;
                i++;
            }
        }
    }
