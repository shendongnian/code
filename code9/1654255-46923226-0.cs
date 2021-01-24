     private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Ontrip _ontrip = new Ontrip(_FNAME);
            string _query2 = "select CContactno from CustomerTbl where CUsername = @USERNAME";
            string _query3 = "select Price from TransactionTypeTble T join PendingTransTbl P ON P.TransType = T.TransType ";
            string _query4 = "select VehicleDescription from DriverTbl D join VehicleSpecTbl V ON D.VehicleType = V.VehicleType";
            SqlConnection _sqlcnn = new SqlConnection("Data Source=MELIODAS;Initial Catalog=WeGo;Integrated Security=True;MultipleActiveResultSets=True ");
            _sqlcnn.Open();
