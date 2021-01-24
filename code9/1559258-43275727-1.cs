      [HttpPost]
        public ActionResult SaveScheduleAppointment(string CustName, string schedDate, string _startTime, string _endTime)
        {
          using(var db = new DCDBEntities())
            {
             //Here - use ScheduleAppointment not SchedAppointment
             ScheduleAppointment schedApt = new ScheduleAppointment
              {    
                // You may also need to change your properties to ones in the new class                
               appointmentDate = schedDate,
               customerFullName = "",
               appointmentDescription = "",
               customerPatientId = 0,
               endTime ="",
               startTime = ""
               };
               //Alternatively, you might need to change this bit to a list of SchedAppointment 
               db.ScheduleAppointments.Add(schedApt);
               db.SaveChanges();
             }
            return View();
        }
