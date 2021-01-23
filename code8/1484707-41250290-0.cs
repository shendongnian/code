            var temp = driver.FindElement(By.ClassName("CoveoQuerySummary"), 10);
            IWebElement body = driver.FindElement(By.ClassName("CoveoResultList"));
            if (body.Text.Contains(searchtext))
                result = true;
            Assert.IsTrue(result);
