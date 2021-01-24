    private bool IsInputDateMatch(InputDate inputDate, DateTime date)
        {
            if (inputDate.Day != 0 && date.Day != inputDate.Day)
                return false;
            if (inputDate.Month != 0 && date.Month != inputDate.Month)
                return false;
            if (inputDate.Year != 0 && date.Year != inputDate.Year)
                return false;
    
            return true;
        }
