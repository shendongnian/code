    [HttpGet]
    public ActionResult DBLookupIndex(DBLookupDTO dto)
    {
        SetAreas(dto);
        return View(dto);
    }
    [HttpGet]
    public ActionResult Search(DBLookupDTO dto)
    {
        dto.Orders = _oh.GetOrders(dto.OrderNumber, dto.ProductNumber, dto.DateRange, dto.SelectDeleted, dto.AreaId);
        SetAreas(dto);
        return View("DBLookupIndex", dto);
    }
    private void SetAreas(DBLookupDTO dto)
    {
        dto.Areas = _ph.GetProfiles();
    }
