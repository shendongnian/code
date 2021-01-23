    var query = DbContext.EquipmentLives
        .Where(l => true)
        .Join(DbContext.EquipmentStatuses.Where(s => s.DateTo == null),
            eq => eq.Id,
            status => status.EquipmentId,
            (eq, status) => new SelectListItem
            {
                EquipmentStatusId = status.Id,
                StatusStartDate = status.DateFrom
            });
