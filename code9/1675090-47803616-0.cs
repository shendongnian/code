     private void CheckTime(object sender, EventArgs e)
      {
         switch (DateTime.Now.DayOfWeek.ToString())
         {
            case "Saturday":
               {
                  DoSomething();
                  break;
               }
            case "Sunday":
               {
                  DoNothing();
                  break;
               }
         }
      }
