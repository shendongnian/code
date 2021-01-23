    public Button AttachMethodToButton(Button b, Action buttonMethod)
    {
        b.Click += (s, e) => buttonMethod();
        return b;
    }
