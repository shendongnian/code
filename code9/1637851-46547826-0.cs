    for (int i = 0;; i < stopLimit.Count; i++)
    {
         try
         {
              Thread.Sleep(500);
              string score = Driver.FindElementByCssSelector("#parts > tbody > 
                                                       tr:nth-child(2) > td.score").Text;
              firstHalf[i] = score.Replace(" ", "");
         }
         catch(Exception)  
         {
              i--;
              Thread.Sleep(1500);
              Driver.SwitchTo().Window(Driver.WindowHandles.Last());
              Driver.Close();
              Driver.SwitchTo().Window(Driver.WindowHandles.First());
         }
    }
