    class MyController
    {
        static private readonly Dictionary<string,Func<BaseTemplate>> _templateList = new Dictionary<string,Func<BaseTemplate>>();
        static MyController() 
        {
            _templateList.Add("ATemplate",         () => return new ATemplate());
            _templateList.Add("SomeOtherTemplate", () => return new SomeOtherTemplate());
            _templateList.Add("JustOneMore",       () => return new JustOneMore());
        }
          
        public ActionResult AddComplianceForm(string TemplateName)
        {
            BaseTemplate template;
            try
            {
                template = _templateList[TemplateName]();
            }
            catch (KeyNotFoundException exception)
            {
                RedirectToAction("MyController", "InvalidTemplateError");
            }
            DoSomethingWithTemplate(template);
        }
    }
