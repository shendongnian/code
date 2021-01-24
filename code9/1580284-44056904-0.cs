     public class CarModel
    {
        public int CarId { get; set; }
        public string CarMake { get; set; }
        public string theCarModel { get; set; }
    }
    public class HomeController : Controller
    {
        public PartialViewResult getUpdate(int carId)
        {
            CarModel carModel = new CarModel();
            switch (carId)
            {
                case 1:
                    carModel.CarId = 1;
                    carModel.CarMake = "updated11111Make";
                    carModel.theCarModel = "updated11111Model";
                    break;
                case 2:
                    carModel.CarId = 2;
                    carModel.CarMake = "updated2Make";
                    carModel.theCarModel = "updated22222Model";
                    break;
                case 3:
                    carModel.CarId = 3;
                    carModel.CarMake = "updated3Make";
                    carModel.theCarModel = "updated33333Model";
                    break;
                default:
                    break;
            }
            return PartialView("_PartialView", carModel);
        }
        public ActionResult Index700()
        {
            IList<CarModel> carModelList = Setup();
            return View(carModelList);
        }
