    public class OpticalcTestViewModel
    {
        public double OD_Sphere { get; set; }
        public double OD_Cylinder { get; set; }
        public int Axis { get; set; }
        public double sphereRadius { get; set; } // new calculated property
    }
    [HttpPost]
    public ActionResult Index(OpticalcTestViewModel model)
    {
        double sphereRadius = model.OD_Sphere / 2; // demo calc
        model.sphereRadius = sphereRadius;
        return View(model);
    }
