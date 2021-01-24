    public async Task<int> ChangeStatus(DriverStatus driverStatus)
    {
        using (IDbConnection connection = DapperConnection)
        {
            var updateQuery = @"UPDATE [dbo].[DriverLocation] Set [Latitude]=@Latitude, [Longitude]=@Longitude, [IsOnline]=@IsOnline Where [DriverId]=@DriverId";
            return await connection.ExecuteAsync(updateQuery, new
            {
                Latitude = driverStatus.Latitude,
                Longitude = driverStatus.Longitude,
                IsOnline = driverStatus.IsOnline,
                DriverId = driverStatus.DriverId
            });
        }
    }
