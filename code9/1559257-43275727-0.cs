      [HttpPost]
        public ActionResult SaveScheduleAppointment(string CustName, string schedDate, string _startTime, string _endTime)
        {
          using(var db = new DCDBEntities())
            {
             SchedAppointment schedApt = new SchedAppointment
              {                    
               appointmentDate = schedDate,
               customerFullName = "",
               appointmentDescription = "",
               customerPatientId = 0,
               endTime ="",
               startTime = ""
               };
               db.ScheduleAppointments.Add(schedApt);
               db.SaveChanges();
             }
            return View();
        }
