    var keyword = Convert.ToString(ViewBag.Keyword);
    var arr = name.Split(new string[] { " and " }, StringSplitOptions.None);
    
    for (int i = 0; i < arr.Length; i++)
    {
        if (result.Document.ContactName.IndexOf(arr[i], StringComparison.OrdinalIgnoreCase) != -1)
        {
            // do something
        }
    }
