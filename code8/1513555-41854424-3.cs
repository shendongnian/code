    public static class BusinessToHtmlHelper {
        public static MvcHtmlString FromBusinessObject<T>( this HtmlHelper<T> html, Person person) {
            return html.DisplayFor( m => person );
        }
        //...
    }
