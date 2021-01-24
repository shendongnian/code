    public class BuildModel
    {
        public string theBuildModel { get; set; }
        public int ConfigID { get; set; }
        public string BuildLocation { get; set; }
        public string EmailCoverity { get; set; }
        public string EmailNightly { get; set; }
        public bool IsCoverity { get; set; }
        public bool IsNightly { get; set; }
    }
    public class GetData
    {
        public IList<BuildModel> GetDataFromTable()
        {
            IList<BuildModel> list = new List<BuildModel>();
            var buildModel1 = new BuildModel { theBuildModel = "one" };
            var buildModel2 = new BuildModel { theBuildModel = "two" };
            var buildModel3 = new BuildModel { theBuildModel = "three" };
            list.Add(buildModel1);
            list.Add(buildModel2);
            list.Add(buildModel3);
            return list;
        }
    }
    public class HomeController : Controller
    {
        [HttpPost]
        public ViewResult SaveData(BuildModel buildModel)
        {
            GetData getdata = new GetData();
            var model = getdata.GetDataFromTable();
            return View("IndexStackOverflow", model);
        }
        [HttpGet]
        public PartialViewResult SaveData(int configID)
        {
            BuildModel model = new BuildModel();
            PopulateBuildLocations();
            PopulateStreams();
            //Create
            if (configID != 0)
            {
                GetData getdata = new GetData();
                model = getdata.GetDataFromTable().Where(co => co.ConfigID == configID).FirstOrDefault();
            }
            else
            {
                model.BuildLocation = "";
                model.EmailCoverity = "";
                model.EmailNightly = "";
                model.IsCoverity = false;
                model.IsNightly = false;
            }
            return PartialView("_PartialModal", model);
        }
        public void PopulateBuildLocations()
        {
            string reportTypes = ConfigurationManager.AppSettings["ddlStreams"].ToString();
            ViewBag.BuildLocations = reportTypes.Split('|')
                .Select((text, value) => new SelectListItem { Text = text, Value = value.ToString() });
        }
        public void PopulateStreams()
        {
            List<string> lstStreams = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                lstStreams.Add("Stream " + i);
            }
            ViewBag.Streams = lstStreams.Select((text, value) => new SelectListItem { Text = text, Value = value.ToString() });
        }
        
        public ActionResult IndexStackOverflow()
        {
            GetData getdata = new GetData();
            return View(getdata.GetDataFromTable());
        }
