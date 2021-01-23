    using OpenQa.Selenium.Webdriver.Extensions
    
    driver.ExecuteJavascript<string>(`
    var els = document.getElementsByClassName("entry entryWriteable");
    string returnAllElementTexts = "";
    for(var i = 0; i < els.length; i++) {
    
        returnAllElementTexts += els[i] + "|";
    
    }
    return returnAllElementText;`);
