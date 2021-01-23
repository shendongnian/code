    public override nint GetRowsInComponent(UIPickerView picker, nint component)
    {
        switch (component)
        {
            case 0:
                return 1;
            case 1:
                return values.Count;
            default:
                // However you want to handle
        }
    }
