    ProviderQualification providerQualification = reporting.GetProviderQualification();
    var items = providerQualification.ProviderDetails
                .Select(detail => new ProviderQualificationDetail
                    {
                        ProviderName = detail.ProviderName,
                        TotalServiceableOffers = detail.ServiceableOffers
                    })
                .ToList();
    var viewModel = new ProviderQualificationTimeViewModel
    {
        ProviderQualificationDetails = items
    };
