    public class TheModel
    {
        public SQL_Table TableInModel { get; set; }
        
        public DateTime Date {get;set;} // <- apply your format HERE
    }
    [HttpPost]
    public ActionResult ControllerName(TheModel mod)
    {
        mod.TableInModel = db.SQL_Table.First();
        mod.Date = mod.TableInModel.Date; 
    }
