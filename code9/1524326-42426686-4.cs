        // insert a new version
        T newVersion = (T)MemberwiseClone();
        newVersion.IsSuspended = true;
        newVersion.RealEffectiveDate = RealExpirationDate;
        newVersion.RealExpirationDate = NullDate;
        newVersion.Version++;
        newVersion.BusinessEffectiveDate = BusinessExpirationDate;
        newVersion.BusinessExpirationDate = NullDate;
