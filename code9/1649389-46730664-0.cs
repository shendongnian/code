	public IEnumerable<ViewItemModel> LoadView(int registratorId)
	{
		var itemModel = from item in _itemQuery
						join header in _headerQuery on item.AnnouncementHeaderID equals header.ID
						where header.RegistratorID == registratorId && !(from hidden in _headerHiddenQuery where hidden.ItemID == item.ID && hidden.Type == GlobalType.One && hidden.RegistratorID == registratorId select hidden.ID).Any()
						orderby item.ID descending
						select new {
							Type = GlobalType.One,
							ID = item.ID,
							Name = header.Name,
							DateCreated = header.DateCreated,
							TypeOfTransport = header.TypeOfTransport,
							TransportType = item.TransportType,
							
							Count = (from subItems in _subItemQuery where subItems.ItemID == item.ID select subItems.ID).Count(),
							// For Status
							IsArchived = header.IsArchived,
							IsCanceled = header.IsCanceled,
							Process = header.Process,
							End = header.End,
							IsPublished = header.IsPublished,
							OpenFrom = header.OpenFrom,
							OpenTill = header.OpenTill,
							IsNextStarted = header.IsNextStarted
						};
						
		return itemModel
				.ToList()
				.Select(it => new ViewItemModel() {
					
					Type = it.Type,
					ID = it.ID,
					Name = it.Name,
					DateCreated = it.DateCreated,
					TypeOfTransport = it.TypeOfTransport,
					TransportType = it.TransportType,
					
					Count = it.Count,
					// For Status
					IsArchived = it.IsArchived,
					IsCanceled = it.IsCanceled,
					Process = it.Process,
					End = it.End,
					IsPublished = it.IsPublished,
					OpenFrom = it.OpenFrom,
					OpenTill = it.OpenTill,
					IsNextStarted = it.IsNextStarted
					
				})
				.ToList();
	}
