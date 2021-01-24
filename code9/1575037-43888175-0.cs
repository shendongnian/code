    protected void Application_Error()
            {
                if (this.Context.AllErrors != null)
                {
                    var p = Path.Combine(Server.MapPath("~"), "Errors.log");
    
                    var message = DateTime.Now.ToString();
                    message = message + " " + this.Context.User.Identity.Name;
                    message = message + " " + this.Context.Request.Url;
                    message = message + Environment.NewLine;
    
                    message = message + "Post";
                    message = message + Environment.NewLine;
    
                    string[] keys = this.Context.Request.Form.AllKeys;
                    for (int i = 0; i < keys.Length; i++)
                    {
                        message = message+keys[i] + ":" + this.Context.Request.Form[keys[i]];
                        message = message + Environment.NewLine;
                    }
    
                    message = message + Environment.NewLine;
                    // you can handle message 
                    message = message+ HttpUtility.HtmlEncode(this.Context.AllErrors[0]);
                    message = message + Environment.NewLine;
                    message = message + "----------------------------------";
                    message = message + Environment.NewLine;
    
    
    
                    System.IO.File.AppendAllText(p, message);
    
    
                    //you can redirect ugly server error page to the one you created
                }
            }
