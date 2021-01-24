    public static BikeModel ConvertToModel(BikeTable dbTable)
    {
        var bikeModel =
            new BikeModel(dbTable.Name, dbTable.Height, dbTable.Width);
            
        if (dbTable.AdditionalProps != null)
        {
            bikeModel.AddNewNumericParam(dbTable.AdditionalNumericParams);
        }
    
        return tenantEntity;
    }
