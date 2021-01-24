    public class Obj1
    {
       public int id {get; set}
       public string field1 {get; set;}
       public string field2 {get; set;}
       public string DisplayField {get {return field1 + " " + field2;}}
    }
    //In your controller
    public ActionResult Create()
    {
       ...other code
       List<Obj1> list = GetAllObj1(); //however you get the fields
       ViewBag.Fields = new SelectList(list, "id", "DisplayField");
       return View();
    } ...
