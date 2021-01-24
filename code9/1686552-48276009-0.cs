    transName = driver.FindElement(By.xxxx);
    
    if(transName.Displayed) {
       Assert.That(transName.Text.Equals(p0));
    }
    else {
       accName= driver.FindElement(By.xxxx);
       if(accName.Displayed) {
         Assert.That(accName.Text.Equals(p0));
       }
       else {
         Assert.That(True.Equals(False))
       }
    }
