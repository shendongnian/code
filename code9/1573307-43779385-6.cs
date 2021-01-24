    [HttpPost]
      public ActionResult AppointmentStatusPage(BookAppointment bookAppointment)
    {
        try
        {
            if (!string.IsNullOrEmpty(Session["UserID"].ToString()) && !string.IsNullOrEmpty(bookAppointment.TransactionStatus))
            {
                return View(bookAppointment);
            }
            else
                return RedirectToAction("guestsearch", "Home");
        }
        catch (Exception ex)
        {
            return null;
        }
    }
