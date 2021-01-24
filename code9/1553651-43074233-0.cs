    public static MyMessageBoxButton Convert(MessageBoxButtons input)
    {
        MyMessageBoxButton result;
        switch (input)
        {
            case MessageBoxButtons.OK:
                result = MyMessageBoxButton.OK;
                break;
            case MessageBoxButtons.OKCancel:
                result = MyMessageBoxButton.OKCancel;
                break;
            case MessageBoxButtons.RetryCancel:
                result = MyMessageBoxButton.NowLaterCancel;
                break;
            case MessageBoxButtons.YesNo:
                result = MyMessageBoxButton.YesNo;
                break;
            case MessageBoxButtons.YesNoCancel:
                result = MyMessageBoxButton.YesNoCancel;
                break;
            default:
                // AbortRetryIgnore will fall through to this
                result = MyMessageBoxButton.OKCancel;
                break;
        }
        return result;
    }
