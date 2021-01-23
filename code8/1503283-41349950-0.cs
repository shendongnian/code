    var menu = "Country";
    var pageClass = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                from pageType in asm.GetTypes()
                let ctor = pageType.GetConstructor(new [] {typeof(IWebDriver)})
                let load = pageType.GetMethod("Load", Type.EmptyTypes)
                where pageType.Name.EndsWith("Page")
                && pageType.Name.StartsWith(menu, StringComparison.InvariantCultureIgnoreCase)
                && ctor != null
                && load != null
                select new { Constructor = ctor, Load = load}).Single();
           
     var page = pageClass.Constructor.Invoke(new []{webdriver});
     var result = pageClass.Load.Invoke(page, null);
     // result has now your CountryPage instance
