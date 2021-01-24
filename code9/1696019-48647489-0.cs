    static ClickBox createClickBox(Action<ClickBox> subscribe)
    {
        var result = new ClickBox();
        subscribe(result);
        return result;
    }
