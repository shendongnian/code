    WebDriverWait wait = new WebDriverWait(Driver.Instance, new TimeSpan(0,0,5));
    wait.Until(ExpectedConditions.ElementExists(By.Id("id-a")));
    wait.Until(ExpectedConditions.ElementExists(By.Id("id-b")));
    wait.Until(ExpectedConditions.ElementExists(By.Id("id-c")));
    return true;
