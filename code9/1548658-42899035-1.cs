    foreach (IWebElement item in webDriver.ElementleriBul(By.XPath("//button//span"), gecisScreen))
    {
         if (item.Text.In("Yükle"))
         {
              item.Tikla();
              break;
         }
    }
