        DataTable Titles = new DataTable();
        SqlConnection connection = new SqlConnection(AssessmentData.GetConnection());
        connection.Open();
        SqlCommand sqlGetTitles = new SqlCommand("[HRO_AAT].[dbo].[GetPositionLibrary]", connection);
        sqlGetTitles.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataAdapter sqlTitles = new SqlDataAdapter(sqlGetTitles);
        sqlTitles.Fill(Titles);
        connection.Close();
        gvPositions.DataSource = Titles.DefaultView;
}
