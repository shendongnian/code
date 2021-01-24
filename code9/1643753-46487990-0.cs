    public PinLoginPageModel()
    {
        NumberCommand = new Command<object>(NumpadToNumber);
    }
    void NumpadToNumber(object obj)
    {
        if((obj as int) == 0)
            PincodeMasked = "0";/
    }
