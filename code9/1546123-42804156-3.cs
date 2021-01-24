     string connString = Utility.Common.GetConnectionString();
            public ReportViewModel GetReportViewModel()
            {
                ReportViewModel reportViewModel = new ReportViewModel();
    
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
    
                    using (var multi =
                                    conn.QueryMultiple("GetReportViewModel", null, null,
                                    commandTimeout: 0,
                                    commandType: CommandType.StoredProcedure))
                    {
                        reportViewModel.HubList = multi.Read<Hub>().ToList();
                        reportViewModel.OpcoList = multi.Read<Opco>().ToList();
                    }
                }
                return reportViewModel;
            }
