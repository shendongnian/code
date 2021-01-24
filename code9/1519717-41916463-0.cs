        void OnItemsSourceChanged(bool fromGrouping = false)
		{
			ListProxy.CollectionChanged -= OnProxyCollectionChanged;
			IEnumerable itemSource = GetItemsViewSource();
			if (itemSource == null)
				ListProxy = new ListProxy(new object[0]);
			else
				ListProxy = new ListProxy(itemSource);
			ListProxy.CollectionChanged += OnProxyCollectionChanged;
			OnProxyCollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
