    if (iscallback)
                {
                   context.Response.Write("eRedirect0:" + url);
                }
                else if (isget || ispost)
                {  
                    context.Response.Clear();
                    context.Response.Write("<script language=javascript>");
                    context.Response.Write(String.Format("window.open(\"{0}\",\"{1}\");", url, "main"));
                    context.Response.Write("</script>");
                }
