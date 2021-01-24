    [Route("createticket")]
    public ActionResult CreateTicket()
    {
         //Irrelevant code ommited
         var data = GetSomeDataYouWantToPrefill();
         var model = new CreateTicketModel(data);
         return View("CreateTicket", model);
    }
