    public class tbl_patnici
    {
       public int pID { get; set; }
       public string firstname { get; set; }
       public string lastname { get; set; }
       //[NotMapped] If you use entityframework then you must use NotMapped attribute.
       public string fullname { get { return this.firstname + " " + this.lastname; } }
    }
    ViewBag.patnikID = new SelectList(db.tbl_patnici, "pID", "fullname");
