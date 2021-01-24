    dynamic oReturn = new ExpandoObject();
    oReturn.Name = name;
    oReturn.Editing = editing;
    oReturn.Img = img;
        
    var json = JsonConvert.SerializeObject(oReturn );
    return Content(json, "application/json");
