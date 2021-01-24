    _unitOfWork.PlacementFinancialViewRepository.GetEfs07Placements().Where(x => x.FiscalYear == fiscalYear && x.ResponsibleSauId == responsibleDistrictId)
    .ToList()
    .Select(x => new Efs07PlacementModel
    {
        PlacementStartDate = x.PlacementStartDate == null ? null : x.PlacementStartDate,
        PlacementEndDate = x.PlacementEndDate == null ? null : x.PlacementEndDate
    }).ToList();
