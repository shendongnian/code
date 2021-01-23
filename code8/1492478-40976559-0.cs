    public class Frame
    {
        public int FrameNr { get; set; }
        public int Pins { get; set; }
        public int Score { get; set; }
    }
    public class FrameController : Controller
    {
        //...
        // GET: Frames
        public ActionResult Index()
        {
            //replace this with your actual data from the database
            var vm = new List<Frame>
            {
                new Models.Frame { FrameNr = 1, Pins = 5, Score = 5},
                new Models.Frame { FrameNr = 2, Pins = 6, Score = 5},
                new Models.Frame { FrameNr = 3, Pins = 7, Score = 5},
                new Models.Frame { FrameNr = 5, Pins = 8, Score = 5},
                new Models.Frame { FrameNr = 9, Pins = 9, Score = 5},
                new Models.Frame { FrameNr = 12, Pins = 10, Score = 5},
            };
            //pass data to view
            return View(vm);
        }
    }
