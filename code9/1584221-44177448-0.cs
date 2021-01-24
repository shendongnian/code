    public ActionResult ViewPrescription()
        {
            ClinicManagemet.Models.Prescription model = _service.GetPerscription();
    
            return PartialView(model);
        }
