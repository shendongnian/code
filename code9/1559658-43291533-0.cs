    public static bool IsInRange(this DateTime dateToCheck, string[] startDates, string[] endDates, out DateTime StartDate, out DateTime EndDate)
    {
          if(startDates.Length != endDates.Length)
          {
              throw new ArgumentException("The arrays must have the same length");                       
          }
          DateTime startDate = new DateTime();
          DateTime endDate = new DateTime();
    
          bool isWithinRange = false;
    
          for (int i = 0; i < startDates.Length; i++)
          {
               startDate = Convert.ToDateTime(startDates[i]);
               endDate = Convert.ToDateTime(endDates[i]);
    
               isWithinRange = dateToCheck >= startDate && dateToCheck <= endDate;
    
               if (isWithinRange)  
                   break;
               
                StartDate = startDate;
                EndDate = endDate;
    
                return isWithinRange;
            }
      }
