        @{ 
            var iPageId = 0
            var sViewPath = ((System.Web.Mvc.BuildManagerCompiledView)ViewContext.View).ViewPath;
            
            //for example
            if (sViewPath.ToLower.IndexOf("admin") >= 0)
            {
              iPageId = 1;
            }
            else if (sViewPath.ToLower.IndexOf("dashboard") >= 0)
            {
              iPageId = 2;
            }
            else if (sViewPath.ToLower.IndexOf("vessels") >= 0)
            {
              iPageId = 3;
            }
            else if (sViewPath.ToLower.IndexOf("reports") >= 0)
            {
              iPageId = 4;
            }
        }
