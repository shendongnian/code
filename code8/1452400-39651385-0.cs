    public static void Raise(this Delegate handler, object sender, EventArgs e)
    {
        if (handler != null)
        {
            handler.DynamicInvoke(sender, e);
        }
    }
