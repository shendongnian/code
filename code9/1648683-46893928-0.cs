        private CollectionsController SetupController()
        {
            if (controller != null)
            {
                controller = null;
            }
            if (controllerContext != null)
            {
                controllerContext = null;
            }
            controller = new CollectionsController();
            controller.ControllerContext = new ControllerContext();
            controllerContext = controller.ControllerContext;
            controllerContext.HttpContext = new DefaultHttpContext();
            //The header below is generic don't really care what the device id is
            controllerContext.HttpContext.Request.Headers["device-id"] = "20317";
        }
