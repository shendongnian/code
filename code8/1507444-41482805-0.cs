    private void updateData<T>(string claimId, Func<T> data)
    {
        _LogFactory.LogInfo(this.GetType(), "Call has been made to the client with claim id: " + claimId + "\n");
    
        IDbConnectionFactory maConnectionFactoruy = new DatabaseConnection().getConnection();
        using (var db = maConnectionFactoruy.Open())
        {
            db.Update<T>(data(), where: callDetail => callDetail.ClaimId == claimId);
        }
    }
