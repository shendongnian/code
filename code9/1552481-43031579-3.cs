    using System;
    namespace MvcApplication.Helpers
    {
    	public class TagHelper
    	{
    		public static string DivWithChild(this HtmlHelper htmlHelper, className, string text)
    		{
    			return string.Format("<div class=\"{0}\"><span>{1}</span></div>",className,text);
    		}
    	}
    }
