      public static void SetTempDataMessages(this Controller controller, bool result)
      {
         if (result) 
         {
            controller.TempData["messageSuccess"] = "Some nice success message";
         } 
         else 
         {
            controller.TempData["messageError"] = "Some nice error message";
         }
      }
