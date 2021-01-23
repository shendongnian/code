    [HttpPost]
    public JsonResult AddItem(List<Tmg> tmgs)
    {
       ...
    }
    
    public class Tmg 
    {
        public string name { get; set; }
    }
