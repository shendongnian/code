    public static class MyHtmlHelper
    {
        public static MvcHtmlString MyButton(this HtmlHelper helper,string text)
        {
            string script = @"<script> function MyMethod(){ alert('You clicked the button') ;} </script> ";
            StringBuilder html = new StringBuilder();
            html.AppendLine(script);
            html.AppendLine("<input type = 'submit' value = '"+ text + "' onclick='MyMethod()'");
            html.Append("/>");
            return new MvcHtmlString(html.ToString());
        }
    }
