    public class BuildingController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            var building = new Building();
            return View(building);
        }
        [HttpPost]
        public ActionResult Create(Building building)
        {
            switch (building.Button)
            {
                case "Add Room":
                    if (ModelState.IsValid)
                    {
                        building.Rooms.Add(building.NewRoom);
                        building.NewRoom = new Room();
                        ModelState.Clear();
                        return PartialView("_Room", building);
                    }
                    break;
                case "Create":
                    if (ModelState.IsValid)
                    {
                        // TODO: save to db
                        return Json("Building created successfully.", JsonRequestBehavior.AllowGet);
                    }
                    break;
            }
            return View(building);
        }
    }
