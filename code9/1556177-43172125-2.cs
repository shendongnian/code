    /* MVC for this: */
    // POCO object: - reference this whereever you put it.
    public class EmailEntry
    {
        public String name { get; set; }
        public String email { get; set; }
    }
    // controller/ method: used IEnumerable instead of List as simpler
    public class HomeController : Controller
    {
       [HttpPost]
        public void SaveEmails(IEnumerable<EmailEntry> entries)
        {
            // do stuff with email entries here...validate/save for example
        }
    }
