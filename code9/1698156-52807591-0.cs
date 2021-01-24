    var notificationUrl = this.Url.Action(
                    nameof(ControllerActionMethod),
                    this.ControllerContext.ActionDescriptor.ControllerName,
                    null,
                    this.HttpContext.Request.Protocol,
                    this.HttpContext.Request.Host.ToString())
