    Dictionary<string, Integer> counts = new Dictionary<string, Integer>();
    string lastNum = "";
    foreach (var item in ImageName)
    {
        SetNum = SetNum + 1;
        LinkPath = item.ToString();
        PartNum = ImageItem[SetNum - 1].ToString().Split('_').Last();
        if (lastNum.Equals(PartNum)) {
            counts[lastNum]++;
        }
        else
        {
            counts.Add(PartNum, 0);
            lastNum = PartNum;
        }
        LinkName = "Full Image_" + counts[PartNum];
        var line = SetNum + delimiter + PartNum + delimiter + LinkName + delimiter + LinkPath + delimiter + "Item Maintenance";
        if (PartNum != "Thumbs") 
        {
            writer.WriteLine(line);
        }
    }
