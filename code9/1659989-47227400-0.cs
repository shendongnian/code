    var query = (from sr in db.StudentRequests
                 join r in db.Registrations on sr.RegistrationId equals r.RegistrationId
                 join cc in db.Campus on r.CampusId equals cc.CampusId
                 join c in db.Classes on sr.ClassId equals c.ClassId
                 from tc in db.TutorClasses.Where(t => t.ClassId == sr.ClassId).DefaultIfEmpty()
                 from srt in db.StudentRequestTimings.Where(s => s.StudentRequestId == sr.StudentRequestId).DefaultIfEmpty()
                 from tsr in db.TutorStudentRequests.Where(t => t.StudentRequestId == srt.StudentRequestId && t.TutorId == registrationid).DefaultIfEmpty()
                 where tc.RegistrationId == registrationid
                 select new
                 {
                   StudentRequestId = sr.StudentRequestId,
                   RegistrationId = sr.RegistrationId,
                   Location = sr.Location,
                   PaymentMethod = sr.PaymentMethod,
                   CreatedOn = sr.CreatedOn,
                   ClassName = c.ClassName,
                   CampusName = cc.CampusName,
                   StatusId = tsr.StatusId == null ? 1 : tsr.StatusId,
                   Time = db.StudentRequestTimings.Where(p => p.StudentRequestId == sr.StudentRequestId).Select(p => p.FromTime.ToString().Replace("AM", "").Replace("PM", "") + "-" + p.ToTime)
                   }).ToList().GroupBy(p => new { p.StudentRequestId }).Select(g => g.First()).ToList();
              var model = query.AsEnumerable().Select(x => new TutorDashboard
               {
                  StudentRequestId = x.StudentRequestId,
                  RegistrationId = x.RegistrationId,
                  Location = x.Location,
                  PaymentMethod = x.PaymentMethod,
                  CreatedOn = x.CreatedOn,
                  ClassName = x.ClassName,
                  CampusName = x.CampusName,
                  StatusId = x.StatusId == null ? 1 : x.StatusId,
                  Time = string.Join(",", x.Time),
                   }).ToList().ToPagedList(page ?? 1, 1);
