      public static void SetTempDataMessages(this Controller controller, bool result)
      {
         if (result) 
         {
            TempData["messageSuccess"] = "Some nice success message";
         } 
         else 
         {
            TempData["messageError"] = "Some nice error message";
         }
      }
