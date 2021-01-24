          public ActionResult Index(string startdate = null, string enddate = null)
        {
            if (startdate != null && enddate != null)
            {
                //this will default to current date if for whatever reason the date supplied by user did not parse successfully
                DateTime start = DateManager.GetDate(startdate) ?? DateTime.Now;
                DateTime end = DateManager.GetDate(enddate) ?? DateTime.Now;
                var rangeData = db.Students.Where(x => x.CurrentDate >= start && x.CurrentDate <= end).ToList();
                return View(rangeData);
            }
            return View();
        }
       
          public class DateManager
        {
            /// <summary>
            /// Use to prevent month from being overritten when day is less than or equal 12
            /// </summary>
          static  bool IsMonthAssigned { get; set; }
        
            public static DateTime? GetDate(string d)
            {
                char[] splitsoptions = { '/', '-', ' ' };
                foreach (var i in splitsoptions)
                {
                    var y = 0;
                    var m = 0;
                    var day = 0;
                    if (d.IndexOf(i) > 0)
                    {
               try{
                        foreach (var e in d.Split(i))
                        {
                            if (e.Length == 4)
                            {
                                y = Convert.ToInt32(e);
                              
                                continue;
                            }
                            if (Convert.ToInt32(e) <= 12 && !IsMonthAssigned)
                            {
                                m = Convert.ToInt32(e);
                                IsMonthAssigned = true;
                                continue;
                            }
                            day = Convert.ToInt32(e);
                        }
                        return new DateTime(y, m, day);
                }catch
               { 
                //We are silent about this but we  could set a message about wrong date input in ViewBag    and display to user if this  this method returns null
                }
                    }
                }
                return null;
            }
        }
