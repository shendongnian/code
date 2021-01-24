            public static IWebElement FindElementOnPageScrolling(this IWebDriver driver, By element)
        {
            RemoteWebElement remoteElement = (RemoteWebElement)driver.FindElement(element);
            var foo = remoteElement.LocationOnScreenOnceScrolledIntoView;
            return remoteElement;
        }
