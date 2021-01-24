    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Newtonsoft.Json.Linq;
    
    namespace myProj.Pages
    {
    	public class PostJsonModel : PageModel
    	{
    		public IActionResult OnPost([FromBody] JObject jobject)
    		{
    			// var output = jobject.ToString();
    			return new JsonResult("{ \"resKey\" : \"resVal\" }");
    		}
    	}
    }
