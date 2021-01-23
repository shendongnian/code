    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    
    
    namespace ExportToCSV.Controllers
    {    
        public class HomeController : Controller
        {
            //
            // GET: /Home/
    
            public ActionResult Index()
            {                        
                byte[] data = Encoding.UTF8.GetBytes(GetAllDates());
                var res = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
                return File(res, "text/csv", "DatesList.csv");
            }
    
            public string GetAllDates()
            {
                var sb = new StringBuilder();
                const string separater = ",";
                const string columnEscaper = "\"";
    
                sb.Append("Date");
    
               foreach (var item in Clients.clients)
                {
                    sb.Append(columnEscaper);                
                    sb.Append(item.Dob.ToString("yyyy-MM-dd")); //returns dates of format: `YYYY-MM-DD`
                    sb.Append(columnEscaper);
                    sb.Append(separater);
                    sb.Append("\r");
                }
    
                string output=sb.ToString();
    
                if (output.Contains(",") || output.Contains("\""))
                    output = '"' + output.Replace("\"", "\"\"") + '"';
    
                return output;
            }
    
        }
    
        public class Clients
        {
            public string FirstName { set; get; }
            public string LastName { set; get; }
            public string Email { set; get; }
            public DateTime Dob { set; get; }
            public Clients(string firstname, string lastname, DateTime dob, string email)
            {
                this.FirstName = firstname;
                this.LastName = lastname;
                this.Dob = dob;
                this.Email = email;
            }
    
            public static List<Clients> clients = new List<Clients>
                {
                     new Clients ( "Adam",  "Bielecki",  DateTime.Parse("22-05-1986"),  "adamb@example.com" ),
                     new Clients (  "George1", "Smith",  DateTime.Parse("10-10-1990"),  "george@example.com" ),
                     new Clients (  "George2", "Smith",  DateTime.Parse("10-05-1992"),  "george@example.com" ),
                     new Clients (  "George3", "Smith",  DateTime.Parse("08-12-1998"),  "george@example.com" )
                };
        }
    }
