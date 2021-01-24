    public ActionResult IfPaid(int id)
    {
        Ref_ViewModel = new View_model.View_Model();
        return Ref_ViewModel.GetAllCustomers(id).Any(p => p.Paid == false)
             ? RedirectToAction("Pay", "Account")
             : RedirectToAction("Download");
    }
