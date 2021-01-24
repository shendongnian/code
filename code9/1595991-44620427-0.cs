    public MatchShipmentsToLocationsPage selectJustThisInvoiceRadioButton()
            {
                    
                var applyOptions = _driver.FindElement(applyLocationForLocator);
                //var justThisInvoiceRadioButton = applyOptions.FindElement(By.Id())
                //_driver.FindElement(justThisInvoiceRadioButtonLocator).Click();
    
                //var allFutureShipmentsRadioButtonLocator = applyOptions.FindElement(By.Id("rbAllShipments"));
                //allFutureShipmentsRadioButtonLocator.Click();
                
                var allships = applyOptions.FindElements(By.Name("locationGroup"))[1];
    
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                js.ExecuteScript("arguments[0].click()", allships);
    
    
              //  allships.Click();
                Thread.Sleep(5000);
                return this;
            }
