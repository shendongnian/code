    //this method is just for displaying your Details view. I'm not sure how exactly your code gets to here, since you didn't specify much (apart from a button gets clicked), so if the method signature is wrong, that'll be something for you to fix yourself, or ask another question about
    public ActionResult Details(Appointments appointment)
    {
        return View(appointment);
    }
    //this method receives the postback when the "Confirm Appointment" button is pressed, and updated the appointment details. Then it returns to the user to the same screen, where this time they should see the "Appointment Confirmed" message instead of the button
    [HttpPost]
    public ActionResult ConfirmAppointment(int appointmentID)
    {
      var appt = db.Appointments.Find(appointmentID);
      appt.Confirmed = true;
      db.SaveChanges();
      return View(appt);
    }
