    public class TheModel
    {
        public SQL_Table TableInModel { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult IndexC()
        {
            BreazEntities1 db = new BreazEntities1();
            var mod = new TheModel();
            mod.TableInModel = db.SQL_Table.Find(1);
            //the Key to this solution is that the type in sql
            //is Date instead of DateTime or the "{0:dd-MM-yyyy}"
            //If you insist on datetime then, even if you
            //format the time out of the date, if you bind it
            //back to a datetime field, the time will still be there
            //albeit 00:00:00
            //finds my first, by identity, row in sql_table wich has 
            //TheDate Column that are passing to view and back
            //out to controller          
            return View(mod);
        }
        [HttpPost]
        public ActionResult IndexC(TheModel sql_table)
        {
            //finds my first, by identity, row in sql_table wich has 
            //don't let the code advance past here
            //we can interrogate the sql_table variable and see 
            //that the formatted date is coming back
            var removeTime = sql_table.TableInModel.TheDate.ToShortDateString();
            return View();
        }
