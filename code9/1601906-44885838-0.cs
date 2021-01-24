    public enum DefultBookType : byte
    {
        NotDirect = 0,
        Individual = 1
    }
        
    public ActionResult Application()
    {
        ViewData["BT"] = JsonConvert.SerializeObject(Enum.GetValues(typeof(DefultBookType)), Formatting.Indented, new StringEnumConverter());
        return View();
    }
