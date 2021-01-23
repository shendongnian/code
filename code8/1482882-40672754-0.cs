        public MyController CreateController()
        {            
            var actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ControllerActionDescriptor()
            };
            var controller = new MyController
            {
                ControllerContext = new ControllerContext(actionContext)
            };
            return controller;
        }
