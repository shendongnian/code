        public class LoadAndAnalyzeDataController : Controller
        {
            public ActionResult LoadAndAnalyzeData()
            {
                //It is not clear why you have called your action and controller
                //the same thing. Do you know what your action and controller are?
                //You could use a view bag like this if you really want but it
                //has nothing to do with the property you mentioned in your
                //question...
                ViewBag.servername = "......";
                //Or you could make an instance of the Server class and set your 
                //servername property to a value like this:
                Server myServer = new Server(){ servername = "...." };
                //After making an instance make sure to pass it as a parameter 
                //to your view like this:
                return View(myServer);
            }
            [HttpPost]
            public ActionResult LoadAndAnalyzeData(string servername)
            {
                //do something with servername
                return View();
            }
        }
