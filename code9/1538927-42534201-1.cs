    dynamic oReturn = new ExpandoObject();
    oReturn.Data = new ExpandoObject();
    oReturn.Data.Name = name;
    oReturn.Data.Editing = editing;
    oReturn.Data.Img = img;
    ...
    return oReturn;
