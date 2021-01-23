    path = dsprofile.Tables[0].Rows[0][0].ToString() + "\\" + number + ".jpg";
    if(File.Exists(path)){
        pictureEdit2.Image = Image.FromFile(path);
    }
    else
    {
        pictureEdit2.Image = Image.FromFile("NotFound.jpg");
    }
