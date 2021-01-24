      public static string ConvertDate(DateTime date)
      {
            if (date < new DateTime(1990, 1,1) )
            {
                return "N/A";
            }
            else
            {
                return date.ToString("dd/MM/yyyy");
            }
      }
