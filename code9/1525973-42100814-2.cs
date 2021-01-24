    public JsonResult SerialNumberSearch(string serialnum)
    {
        var result = db.IASerialNoMasters
                       .Where(x => x.SerialNo == serialnum)
                       .Select(x => x.Model).Single().ToString();
        return result;
    }
