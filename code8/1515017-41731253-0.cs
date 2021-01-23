        public string CompileMessage(string templateHtml, object modelClass)
        {
            try
            {
                TemplateServiceConfiguration templateConfig = new TemplateServiceConfiguration
                {
                    Resolver = new TemplateResolver(),
                    Language = Language.CSharp,
                    Debug = true,
                };
                Razor.SetTemplateService(new TemplateService(templateConfig));
                return Razor.Parse(templateHtml, modelCLass);
            }
            catch (Exception ex)
            {
                Logger.Log4Net.Error("Failed to compile email template using Razor", ex);
                return "Error occurred (" + ex.Message + "). Check the logfile in the vicinity of " + DateTime.Now.ToLongTimeString() + ".";
            }
        }
