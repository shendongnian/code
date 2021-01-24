    private void Execute(object parameter)
    {
        IList list = parameter as IList;
        foreach (var item in list)
        {
            Remove((Data)item);
        }
    }
