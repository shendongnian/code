        //Retrieves the checked items from the form and sends them to the page.
            foreach (object checkedItem in vehicleGroupList.CheckedItems)
            {
                //Gets the index of the checked items.
                int checkedIndex = vehicleGroupList.Items.IndexOf(checkedItem);
                //Adds 1 to the index to match format of the page HTML.
                checkedIndex++;
                //Puts the index+1 into a string.
                string indexText = checkedIndex.ToString();
                //Finds the element by index+1.
                var clickTarget = Builder.Driver.FindElement(By.XPath(string.Format("//*[@id='ratingModification_SupplierContact_content']/label[" +indexText+ "]/input")));
                clickTarget.Click();
