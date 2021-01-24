    if (D.ScheduleEndTime != T.EndTime) {
        if (D.ScheduleEndTime.Date < Time.Date) {
            return Json(new { success = "fail", message = "End Time must be greater than current time!!!" }, JsonRequestBehavior.AllowGet);
        }
        else if ((D.ScheduleEndTime.Date == Time.Date) && ((D.ScheduleEndTime.Time < Time.Time) || (D.ScheduleEndTime.Time < T.StartTime))) {
            return Json(new { success = "fail", message = "End Time must be greater than current time!!!" }, JsonRequestBehavior.AllowGet);
        }
    }
