    public void waitForElementAndSelectDD(String dropdown, String option){
            new WebDriverWait(driver,  
  
            TimeSpan.FromSeconds(longTimeout))
            .Until(ExpectedConditions.ElementExists((By.Id(dropdown))));
            SelectElement dropDown = new SelectElement(driver.FindElement(By.Id(dropdown)));
            dropDown.SelectByText(option);
        }
