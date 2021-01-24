    public class EmployeesController : Controller
    {
      public ActionResult Employee()
      {
        EmployeesViewModel model = new EmployeesViewModel();
        SetEquipmentData(model);
        SetOfficeData(model);
        return View(model);
      }
    [HttpPost]
    public ActionResult Employee(EmployeesViewModel model)
    {
        SetEquipmentData(model);
        SetOfficeData(model);
        // remove properties from modelstate in order to get modified values in view
        ModelState.Remove("Name");
        ModelState.Remove("Phone");
        ModelState.Remove("Email");
        //SHOULD GET EMPLOYEE DATA FROM DB BASED ON UserID PROPERTY
        
        // dummy data: 
        model.Name = "John Doe";
        model.Phone = "973-548-85965";
        model.Email = "John@Company.com";
        return View(model);
    }
    private void SetEquipmentData(EmployeesViewModel model)
    {
        // dummy data: 
        model.EquipmentList = new List<Equipment>();
        model.EquipmentList.Add(new Equipment(){EquipmentID = 1, EquipmentName="Hammer"});
        model.EquipmentList.Add(new Equipment() { EquipmentID = 2, EquipmentName = "Screwdriver" });
        model.EquipmentList.Add(new Equipment() { EquipmentID = 3, EquipmentName = "Vise" });
        model.EquipmentList.Add(new Equipment() { EquipmentID = 4, EquipmentName = "Plier" });
        model.EquipmentList.Add(new Equipment() { EquipmentID = 5, EquipmentName = "Saw" });
    }
    private void SetOfficeData(EmployeesViewModel model)
    {
        // dummy data: 
        model.OfficeList = new List<Office>();
        model.OfficeList.Add(new Office() { OfficeID = 10, OfficeName = "Charleston" });
        model.OfficeList.Add(new Office() { OfficeID = 20, OfficeName = "Springfield" });
        model.OfficeList.Add(new Office() { OfficeID = 30, OfficeName = "Montclair" });
        model.OfficeList.Add(new Office() { OfficeID = 40, OfficeName = "Louisville" });
        model.OfficeList.Add(new Office() { OfficeID = 50, OfficeName = "Albany" });
    }
    }
