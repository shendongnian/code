    class MyController
    {
        static readonly List<string,Func<object>> _templateList;
        static MyController() 
        {
            _templateList.Add("ATemplate",         () => return new ATemplate());
            _templateList.Add("SomeOtherTemplate", () => return new SomeOtherTemplate());
            _templateList.Add("JustOneMore",       () => return new JustOneMore());
        }
          
        public ActionResult AddComplianceForm(string TemplateName)
        {
            var template;
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
