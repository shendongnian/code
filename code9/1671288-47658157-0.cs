    public ActionResult Delete(int id, SendFaxVm vm, Fax fax)
    {
        if (SendFaxVm == null || Fax == null)
        {
            return RedirectToAction("FaxForm", "Fax");
        }
        foreach (var userId in vm.SelectedEmployees)
        {
            var faxdatadelete = Db.FaxDatas.FirstOrDefault(f => f.FaxId == fax.Id);
            if (faxdatadelete != null)
            {
                Db.FaxDatas.Remove(faxdatadelete);
                Db.SaveChanges();
            }
        }
        var deletedfax = Db.Faxes.FirstOrDefault(f => f.Id == id);
        if (deletedfax != null)
        {
            Db.Faxes.Remove(deletedfax);
            Db.SaveChanges();
        }
        return RedirectToAction("FaxForm", "Fax");
    }
