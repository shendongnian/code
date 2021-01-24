    MultiLineInput getPOList = new MultiLineInput();
    getPOList.ShowDialog();
    var wholeText = getPOList.listOfPOs.Text;
    var lines = wholeText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
    foreach (string po in getPOList.listOfPOs.Text)
    {
        pos.Add(po);
    }
    //Etc.....   
