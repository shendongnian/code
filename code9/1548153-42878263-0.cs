    SELECT
      AdvertiserMaster.AdvertiserID,
      AdvertiserMaster.BusinessName,
      ISNULL(AdvertiserMaster.AverageRating, 0) AS AverageRating,
      AdvertiserMaster.ImageURL1,
      AdvertiserMaster.Address1,
      AdvertiserMaster.CategoryID,
      AdvertiserMaster.Email,
      AdvertiserMaster.CountryID,
      AdvertiserMaster.StateID,
      AdvertiserMaster.CityID,
      AdvertiserMaster.PinCode,
      AdvertiserMaster.Mobile,
      CategoryMaster.CategoryName,
      CountryMaster.CountryName,
      StateMaster.StateName,
      CityMaster.CityName,
      COUNT(ReviewDetails.Review) AS ReviewCount
    FROM AdvertiserMaster
    INNER JOIN BusinessCategoryDetails
      ON AdvertiserMaster.AdvertiserID = BusinessCategoryDetails.AdvertiserID
    INNER JOIN ReviewDetails
      ON AdvertiserMaster.AdvertiserID = ReviewDetails.AdvertiserID
    LEFT OUTER JOIN CategoryMaster
      ON AdvertiserMaster.CategoryID = CategoryMaster.CategoryID
    LEFT OUTER JOIN CountryMaster
      ON AdvertiserMaster.CountryID = CountryMaster.CountryID
    LEFT OUTER JOIN CityMaster
      ON AdvertiserMaster.CityID = CityMaster.CityID
    LEFT OUTER JOIN StateMaster
      ON AdvertiserMaster.StateID = StateMaster.StateID
    LEFT OUTER JOIN SubCategoryMaster
      ON BusinessCategoryDetails.SubCategoryID = SubCategoryMaster.SubCategoryID
    WHERE (AdvertiserMaster.CategoryID = 8)
    AND (AdvertiserMaster.CityID = 16619)
    AND (AdvertiserMaster.IsActive = 1)
    GROUP BY AdvertiserMaster.AdvertiserID,
             AdvertiserMaster.BusinessName,
             ISNULL(AdvertiserMaster.AverageRating, 0),
             AdvertiserMaster.ImageURL1,
             AdvertiserMaster.Address1,
             AdvertiserMaster.CategoryID,
             AdvertiserMaster.Email,
             AdvertiserMaster.CountryID,
             AdvertiserMaster.StateID,
             AdvertiserMaster.CityID,
             AdvertiserMaster.PinCode,
             AdvertiserMaster.Mobile,
             CategoryMaster.CategoryName,
             CountryMaster.CountryName,
             StateMaster.StateName,
             CityMaster.CityName
