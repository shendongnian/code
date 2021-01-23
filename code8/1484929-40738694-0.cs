    string _width = context.Request.QueryString["w"];
    string _height = context.Request.QueryString["h"];
    string text = context.Request.QueryString["t"];
    string text_size = context.Request.QueryString["ts"];
    string text_background_color = context.Request.QueryString["bg"];
    int __width = 300;
    int __height = 200;      
    int __text_size = 10;
    
    if (!string.IsNullOrEmpty(_width))
    {
        __width = Convert.ToInt32(_width);
    }
    
    if (!string.IsNullOrEmpty(_height))
    {
        __height = Convert.ToInt32(_height);
    }
    
    if (!string.IsNullOrEmpty(text_size))
    {
        __text_size = Convert.ToInt32(text_size);
    }
    
    if (!string.IsNullOrEmpty(text_background_color))
    {
        text_background_color = "#" + text_background_color;
    }
    else
    {
        text_background_color = "#000000";
    }
