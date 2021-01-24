    private void OnBinListChanged(object sender, ListChangedEventArgs e)
    {
        switch (e.ListChangedType)
        {
            case ListChangedType.ItemAdded:
                BindingListEventRaiseCount++;
                Console.WriteLine("Current ListElementsCount: " + ((BindingList<int>)sender).Count);
                break;
            case ListChangedType.Reset:
                Console.WriteLine("Reset");
                break;
        }
    }
