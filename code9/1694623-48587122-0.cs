    1. var button = document.getElementById("....");
       button.click(); 
    2. Actions action = new Actions(_driver);  
      action.MoveToElement(driver.FindElement(By.Id(".....")));
      action.Click().Build().Perform();
