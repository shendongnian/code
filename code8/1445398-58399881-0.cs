    public override async Task Invoke(IOwinContext context) {
            try {
                await Next.Invoke(context);
            } catch (Exception ex) {
                _errorHandling = new ErrorHandling();
                if (ex.Message.Contains("IDX10803")) {
                    //do something here to alert your IT staff to a possible IdSvr outage
                    context.Response.Redirect("/Error/IdSvrDown?message=" + ex.Message);
                } else if(ex.Message.Contains("IDX10311") && context.Request.Host.Value.Contains("localhost")) {
                    //absorb exception and allow middleware to continue
                } else {
                    context.Response.Redirect("/Error/OwinMiddlewareError?exMsg=" + ex.Message + "&owinContextName=" + lastMiddlewareTypeName);
                }
            }
        }
