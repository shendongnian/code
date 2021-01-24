        public override void OnException(ExceptionContext errorContext)
        {
            string actionName = errorContext.RouteData.Values["action"] as string;
            MethodInfo method = errorContext.Controller.GetType().GetMethods()
                .FirstOrDefault(x => x.DeclaringType == errorContext.Controller.GetType() 
                                && x.Name == actionName);
            IEnumerable<Attribute> attributes = method.GetCustomAttributes();
          
            //DoStuff
        }
