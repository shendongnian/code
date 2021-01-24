    [Route("cloud/getTicketCount")]
    public JsonResult getTicketCount()
    {
        var tickets = Dashboard.getTODTickets("On Hold"); 
        return Json(tickets ,JsonRequestBehavior.AllowGet);
    }
