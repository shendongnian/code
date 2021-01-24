        public FMDRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public bool UpdateRealProductions(IEnumerable<MakerInfo> makersInfo)
        {
            if (makersInfo == null) return false;
            OpenConnection();
            foreach (var makerInfo in makersInfo)
            {
                var success = ExecuteNonQuery(
                      String.Format("UPDATE [Shooter] SET [RealProduction]={0}, [LastUpdate]='{1:yyyy-MM-dd HH:mm:ss}' WHERE [Machine]='{2}'",
                          Math.Round(makerInfo.RealProduction, 0), DateTime.Now,
                          makerInfo.Machine));
                if (success == -1)
                {
                    CloseConnection();
                    return false;
                }
            }
            CloseConnection();
            return true;
        }
    }
