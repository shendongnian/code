    protected void ExportToImage(object sender, EventArgs e)
    {
        string base64 = Request.Form[hfImageData.UniqueID].Split(',')[1];
        byte[] bytes = Convert.FromBase64String(base64);
        //write the bytes to file:
        File.WriteAllBytes(@"c:\temp\somefile.jpg", bytes); //write to a temp location.
        File.Copy(@"c:\temp\somefile.jpg", @"\\192.168.2.9\Web");//here we grab the file and copy it.
        //EDIT: based on permissions you might be able to write directly to the share instead of a temp folder first.
    }
