    int sameNumCount = 0;
    string lastNum = "";
    foreach (var item in ImageName)
    {
        SetNum = SetNum + 1;
        LinkPath = item.ToString();
        PartNum = ImageItem[SetNum - 1].ToString().Split('_').Last();
        if (lastNum.Equals(PartNum)) {
            sameNumCount++;
        }
        else
        {
            sameNumCount = 0;
            lastNum = PartNum;
        }
        LinkName = "Full Image_" + sameNumCount;
        var line = SetNum + delimiter + PartNum + delimiter + LinkName + delimiter + LinkPath + delimiter + "Item Maintenance";
        if (PartNum != "Thumbs") 
        {
            writer.WriteLine(line);
        }
    }
