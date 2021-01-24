    protected override bool TryParse(IMessageActivity message, out T result)
    {
        if (IsCancel(message.Text))
        {
            result = default(T);
            return true;
        }
        return base.TryParse(message, out result);
    }
