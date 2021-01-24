        public DataTable GetMTDReport(bool isDepot, int userId)
        {
            using (IDbConnection _connection = DapperConnection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IsDepot", isDepot);
                parameters.Add("@userId", userId);
                var res = this.ExecuteSP<dynamic>(SPNames.SSP_MTDReport, parameters);
                return ToDataTable(res);
            }
        }
