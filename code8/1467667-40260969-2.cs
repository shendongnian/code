          string sRegxE =dbContext.GetFields.Where(s => s.Name == sColumnName).Select(s => s.ExpressionValue).FirstOrDefault();
          Regex RgxM = new Regex("" + sRegxE + "");
          Match isPhoneNumber = RgxM.Match(sColumnValue);
           if (isPhoneNumber.Success)
             {
               //Do somthing...
             }
