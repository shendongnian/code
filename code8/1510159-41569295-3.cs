    [HttpGet]
    public ActionResult DBLookupIndex(DBLookupDTO dto)
    {
        return SetAreasAndView(dto);
    }
    [HttpGet]
    public ActionResult Search(DBLookupDTO dto)
    {
        dto.Orders = _oh.GetOrders(dto.OrderNumber, dto.ProductNumber, dto.DateRange, dto.SelectDeleted, dto.AreaId);
        return SetAreasAndView(dto);
    }
    private ActionResult SetAreasAndView(DBLookupDTO dto)
    {
        dto.Areas = _ph.GetProfiles();
        return View("DBLookupIndex", dto);
    }
