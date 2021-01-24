	using (var connection = new TReportEntitiesConnection())
	{
		var clientHeaders = (
			from st in connection.THeaders
			where ClientID == st.ClientID
			select new TReportHeaderModel
			{
				ID=st.ID,
				THeaderTitle = st.THeaderTitle,
				RowNumber = st.RowNumber,
				Reports = from r in st.TReports
				          select new TReportModel
						  {
							ID = r.ID,
							TReportName = r.TReportName,
							URL = r.URL,
							RowNumber = r.RowNumber,
						  }
			}
		).ToList();
    }
    return clientHeaders;
