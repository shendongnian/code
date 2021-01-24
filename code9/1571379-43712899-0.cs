	public IObservable<Unit> FavouritesChanged()
	{
		return
			_favourites
				.ObserveCollectionChanged()
				.Select(c =>
					_favourites
						.Select(y => y.ObservePropertyChanged())
						.Merge()
						.AsUnit())
				.Switch();
	}
