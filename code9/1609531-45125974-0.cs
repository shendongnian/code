    public class HomeController : Controller  
        {  
            public string Index(string id, string name)  
            {  
                return "ID =" + id+"<br /> Name="+name;  
            }  
       }
