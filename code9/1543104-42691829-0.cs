    [HttpPost]
    public ActionResult DeleteData(PartnerStudy partner)
    {
        using(var repository = new DomainRepository())
        {
            var partnerStudy = GetByID(partner.Idetity, repository);
            repository.Delete(partnerStudy);
            repository.SaveChanges();
        }
        return RedirectToAction("ShowData");
    }
    private PartnerStudy GetByID(int id, DomainRepository repository)
    {
        var partner = repository.GetItem<PartnerStudy>(id);
        return partner;
    }
