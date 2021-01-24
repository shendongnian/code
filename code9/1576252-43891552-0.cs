                Actions builder = new Actions(ngDriver);
                var elementToClick = ngDriver.FindElement(By.ClassName("dpcontract"));
                builder.MoveToElement(elementToClick, elementToClick.Size.Width - 1, 0)
                .ClickAndHold()
                .MoveByOffset(150, 0)
                .Release();
    
                builder.Build().Perform();
