        using System;
        using RazorEngine;
        using RazorEngine.Templating;
        namespace Project.ServiceLayer.Helpers.EmailBuilder
        {
            public class RazorHtmlBuilder
            {
                public string BuildEmail<T>(string templateName, string template, T model)
                {
                    try
                    {
                        return Engine.Razor.RunCompile(template, templateName, typeof (T), model);
                    }
                    catch (Exception ex)
                    {
                        //log error
                    }
                }
        }
