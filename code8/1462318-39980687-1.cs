    private void UnsubscribeuserPreferenceChanged()
    {
        MethodInfo handler = typeof(RichTextBox).GetMethod("UserPreferenceChangedHandler", BindingFlags.Instance | BindingFlags.NonPublic);
        EventInfo evt = typeof(SystemEvents).GetEvent("UserPreferenceChanged", BindingFlags.Static | BindingFlags.Public);
        MethodInfo remove = evt.GetRemoveMethod(true);
        remove.Invoke(null, new object[]
        {
            Delegate.CreateDelegate(evt.EventHandlerType, null, handler)
        });
    }
