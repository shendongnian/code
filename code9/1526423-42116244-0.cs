    public class CustomViewEngine : WebFormViewEngine
        { 
            public CustomViewEngine(string NewPath)
            {
                var viewLocations = new[] {
                "~/Views1/{1}/{0}.aspx",
                "~/Views1/{1}/{0}.ascx",
                "~/Views1/Shared/{0}.aspx",
                "~/Views1/Shared/{0}.ascx" ,
                Path.Combine(NewPath,"Views/{1}/{0}.aspx"),
                 Path.Combine(NewPath,"Views/{1}/{0}.ascx"),
                Path.Combine(NewPath,"Views/Shared/{0}.aspx"),
                Path.Combine(NewPath,"Views/Shared/{0}.ascx")
    
                // etc
            };
