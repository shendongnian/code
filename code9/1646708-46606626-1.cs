    [HttpPost]
    public ActionResult AddingInternalAppointment([FromBody]AppointmentOptions model) {
        if(ModelState.IsValid) {
            string Start = model.Start;
            string End = model.End;
            //...
        //...code removed for brevity
    }
