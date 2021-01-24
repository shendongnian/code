            if (context.Controller.ControllerContext.IsChildAction)
            {
                context.Result = new PartialViewResult();
            }
            else
            {
                context.Result = new ViewResult();
            }
