    private bool IsMissingAuthorizationStartDate(ApplicationStatusData data)
    {
        return data.ApplicationStatus == ApplicationStatusType.ApplicationApproved
            && (IsMissingAuthorizationStartDatePart2(data, ApplicationPurpose.New,
                    ProductStatusType.ApplicationForNewProductReceived, typePesticidesNewPurpose)
                || IsMissingAuthorizationStartDatePart2(data, ApplicationPurpose.Renewal,
                    ProductStatusType.ProductAuthorised, typePesticidesRenewalPurpose));
    }
    private bool IsMissingAuthorizationStartDatePart2(ApplicationStatusData data,
        ApplicationPurpose purpose, ProductStatusType statusType,
        params ApplicationTypePesticide[] typePesticides)
    {
        return (data.ApplicationPurpose == purpose
            && data.ProductStatus.ProductStatusType == statusType
            && statusType.Any(st => data.ApplicationTypePesticide == st)
            && !data.AuthorizationStartDate.HasValue);
    }
