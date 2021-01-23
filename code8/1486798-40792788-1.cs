    public enum Types { Section, Input, File, Radio, Checkbox, Select };
    // Why did you decide it to be IDisposable? What are you going to dispose?
    public class clsHtml: IDisposable
    {
        public HtmlControl element { get; private set; }
    
        public clsHtml(Types type)
        {
            this.CreateElement(type);
        }
    
        private void CreateElement(Types type)
        {
            switch(type)
            {
                case Types.Input:
                    this.element = new HtmlInputText();
                    break;
    
                case Types.File:
                    this.element = new HtmlInputFile();
                    break;
    
                case Types.Radio:
                    this.element = new HtmlInputRadioButton();
                    break;
    
                case Types.Checkbox:
                    this.element = new HtmlInputCheckBox();
                    break;
    
                case Types.Select:
                    this.element = new HtmlSelect();
                    break;
                default:
                    throw new NotImplementedException(type.ToString() + " not yet supported!");
            }
        }
    
        public override string ToString()
        {
            System.IO.StringWriter writer = new System.IO.StringWriter();
            HtmlTextWriter html = new HtmlTextWriter(writer);
    
            this.element.RenderControl(html);
    
            return writer.ToString();
        }
    }
    var clsHtml = new clsHtml(Types.Input);
    
    // the following part sucks, but you don't want to use generics
    if (clsHtml.element is HtmlInputText)
    {
      HtmlInputText elementAsHtmlInputText = clsHtml.element as HtmlInputText;
    }
    else if ( ...)
    ...
