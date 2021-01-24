    // Temp variable to manipulate, instantiated to passed in custom_datetime D.
    custom_datetime temp = D;
    // First check if the passed in date time is different than date time stored
    if ((temp.Date != T.Date) || ((temp.Date == T.Date) && (temp.endTime != T.endTime))) {
        // Then check if the endTime is less than the startTime
        // If it is, then the end time is the next day so increment the date in temp variable. Now use temp variable to do rest of the checks.
        if (temp.endTime < temp.startTime) {
            temp.Date++; // Increment to next day, so 18/08/2017 becomes 19/08/2017
        }
        //Check if passed in date < stored date, if it is, then it will also be less than startTime so return error.
        if (temp.Date < T.Date) { 
            return Json(new { success = "fail", message = "End Time must be greater than current time!!!" }, JsonRequestBehavior.AllowGet);
        }
        //Check if the passed in date is the same as the stored date. If it is, make sure the endTime is greater than the stored startTime
        else if ((temp.Date == T.Date) && (temp.endTime <= T.startTime)) {
            return Json(new { success = "fail", message = "End Time must be greater than current time!!!" }, JsonRequestBehavior.AllowGet);
        }
        //Check if the passed in date < current system date or if the passed in date == current system date but the endTime <= the current time.
        else if ((temp.Date < Time.Date) || ((temp.Date == Time.Date) && (temp.endTime <= Time.Time)) {
            return Json(new { success = "fail", message = "End Time must be greater than current time!!!" }, JsonRequestBehavior.AllowGet);
        }
    }
