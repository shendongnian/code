     public bool TryMakeDateTime(int year, int month, int day, out DateTime date)
     {
          date = DateTime.MinValue;
          if(!IsValidDay(year, month, day))
            return false;
          date = new DateTime(year, month, day);
          return true;
     }
     public bool IsValidDay(int year, int month, int day)
     {
         if(day < 1 || day > 31)
            return false;
         if(month < 1 || month > 12)
            return false;
         if(day > 30 && (month == 2 ||
                         month == 4 || 
                         month == 6 || 
                         month == 9 || 
                         month == 11))
            return false;
         
         // This is arbitrary, adjust the check to your constraints
         if(year < 1900 || year > 2099)
             return false;
         if(month == 2)
         {
             // IsLeapYear cannot handle values below 1 or higher than 9999
             // but we have already checked the year with more retrictive
             // constraints.
             int extraDay = (DateTime.IsLeapYear(year) ? 1 : 0);
             if(day > (28 + extraDay))
                 return false;
         }
         return true;
     }
