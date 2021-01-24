     public List<MyDate> CheckDates(DateTime groupAStart, DateTime groupAEnd,
                                    DateTime groupBStart, DateTime groupBEnd)
            {
                List<MyDate> myDates=new List<MyDate>();
                for (DateTime date = groupAStart; date <= groupAEnd; date = date.AddDays(1))
                {
                    MyDate myDate = new MyDate();
                    if (date > groupBEnd || groupBStart > date)
                    {
                        myDate.Date = date;
                        myDate.IsValid = false;
                    }
                    if(myDate.Date> DateTime.MinValue)
                      myDates.Add(myDate);
    
                }
                return myDates;
            }
