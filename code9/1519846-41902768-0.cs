    var divData = doc.GetElementbyId("tt_spStatus");
    if (divData != null)
    {
        if (divData.InnerText == null)
        {
            status = divData.InnerText.Replace("\r", "").Replace("\t", "").Replace("\n", "").Trim();
        }
    }
