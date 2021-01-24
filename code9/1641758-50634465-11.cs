    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    
    namespace myProj.Pages
    {
    	public class PostJsonModel : PageModel
    	{
    		public IActionResult OnPost([FromBody] JObject jobject)
    		{
                // request buffer in jobject
    			return new ContentResult { Content = "{ \"resKey\": \"resVal\" }", ContentType = "application/json" };
                // or ie return new JsonResult(obj);
    		}
    	}
    }
