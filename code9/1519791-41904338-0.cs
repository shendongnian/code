    //Your constructor
    public HtmlTextbox(TextboxConfiguration config)
    {
        //config.Position
    }
    //A Transfer class
    public class TextboxConfiguration
    {
        public T Browser { get; set; }
        public T Position { get; set; }
    }
    //Your code
    var config = new TextboxConfiguration
    {
        Browser = browser;
        Position = position;
    }
    var textbox = new HtmlTextbox(config);
