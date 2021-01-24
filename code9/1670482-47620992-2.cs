    List<int> statsView = new List<int>();
    statsView.Add(countWeekDays);
    statsView.Add(countPresents);
    statsView.Add(countAbsence);
    statsView.Add(countLates);
    statsView.Add(countFines);
    return Json(new { list = totalList, statusList = statsView },
                                                         JsonRequestBehavior.AllowGet); 
