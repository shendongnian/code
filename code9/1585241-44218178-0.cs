    public class IdStruct
    {
        public List<int> id { get; set; }
    }
    
    public ActionResult ObjectReceive(IdStruct ids)
    {
       return Content("{success:true}");
    }
