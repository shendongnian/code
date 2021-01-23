     public static int UpdateContract(string ContractNo, DateTime? ContractDate, string ContractDuration, string ServiceStart, string ContractDetails, string ContractValue, string Served)
        {
            string css = ConfigurationManager.ConnectionStrings["dbx"].ConnectionString;
            using (SqlConnection con = new SqlConnection(css))
            {
                string UpdateQuery = "UPDATE SCHOLARSHIPCONTRACT SET ContractDate==COALESCE(@ContractDate=ContractDate), ContractDuration = @ContractDuration, ServiceStart = @ServiceStart, ContractDetails = @ContractDetails, ContractValue= @ContractValue, Served = @Served WHERE ContractNo =@ContractNo";
                SqlCommand UpdateCmd = new SqlCommand(UpdateQuery, con);
                UpdateCmd.Parameters.AddWithValue("ContractNo", ContractNo);
                //Here you have to convert string to DateTime
                UpdateCmd.Parameters.AddWithValue("@ContractDate", ContractDate);
                UpdateCmd.Parameters.AddWithValue("@ContractDuration", ContractDuration);
                UpdateCmd.Parameters.AddWithValue("@ServiceStart", ServiceStart);
                UpdateCmd.Parameters.AddWithValue("@ContractDetails", ContractDetails);
                UpdateCmd.Parameters.AddWithValue("@ContractValue", ContractValue);
                UpdateCmd.Parameters.AddWithValue("@Served", Served);
                con.Open();
                return UpdateCmd.ExecuteNonQuery();
            }
        }
