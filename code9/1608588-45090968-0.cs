    private void TrolleyAllocations_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
          Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
          {
               RaisePropertyChanged("WorkOrderLineItems");
               ForegroundColor = GetForegroundColour();
          }
    }
