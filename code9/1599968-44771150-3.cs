    Dictionary<string, PictureBox> buttonList = new Dictionary<string,PictureBox>();
    string buttonName = "button_file";
    buttonList[buttonName].Click += GetHandler(buttonName + "_click");
    public Action<object, EventArgs> GetHandler(string handlerName)
    {
        var methodInfo = this.GetType().GetMethod(handlerName, new Type[] {typeof(object), typeof(EventArgs)});
        return new Action<object, EventArgs> (sender, eventArgs) => methodInfo.Invoke(this, new [] {sender, eventArgs});
    }
