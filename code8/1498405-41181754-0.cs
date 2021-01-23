    IQueryable<SearchListItem> query = DbContext.EquipmentLives
        .Where(...)
        .Select(e => e.EquipmentStatuses.FirstOrDefault(s => s.DateTo == null))
        .Select(s => new SearchListItem {
            EquipmentStatusId = s.Id,
            StatusStartDate = s.DateFrom,
            ...
        });
