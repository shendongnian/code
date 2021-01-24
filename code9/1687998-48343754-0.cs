    private void UILogRemoveRow(string entryCode)
    {
        var item = UILog.Items.OfType<UILogObject>()
                              .FirstOrDefault(x => x.entryType == entryCode);
        if (item != null)
            UILog.Items.Remove(item);
    }
