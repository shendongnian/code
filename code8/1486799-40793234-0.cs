    public class clsHtml<T>
         where T : HtmlControl, new()
    {
        public T element;
    
        public clsHtml(T type)
        {
            element = new T();
        }
    
        public override string ToString()
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();
            HtmlTextWriter html = new HtmlTextWriter(writer);
    
            element.RenderControl(html);
    
            return writer.ToString();
        }
    }
