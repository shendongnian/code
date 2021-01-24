    foreach (System.IO.DriveInfo item in System.IO.DriveInfo.GetDrives())
    {
        if(item.Name == "C:\\")
        {
            button10.Visible = true;
        }
        else
        {
            button10.Visible = false;
        }
    }
