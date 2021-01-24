    protected override bool TryParse(IMessageActivity message, out T result)
    {
        if (IsCancel(message.Text))
        {
            result = default(T);
            return true;
        }
        var parsingTriedSucceeded = base.TryParse(message, out result);
        // here you know if you found one of the options or not, and if not you override
        if (!parsingTriedSucceeded)
        {
            result = (T)Convert.ChangeType(message.Text, typeof(T));
            return true;
        }
        else
        {
            return parsingTriedSucceeded;
        }
    }
