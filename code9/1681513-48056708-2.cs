    [WebMethod]
    public static void SaveFrmDetails(User user)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conndbprodnew"].ConnectionString;
        using (OracleConnection con = new OracleConnection(connectionString))
        {
            using (OracleCommand cmd = new OracleCommand("INSERT INTO TDC_PRODUCT1(PRODUCT_ID,TDC_NO, REVISION) VALUES (:PRODUCT_ID,:TDC_NO,:REVISION )", con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue(":PRODUCT_ID", user.PRODUCT_ID);
                cmd.Parameters.AddWithValue(":TDC_NO", user.TDC_NO);
                cmd.Parameters.AddWithValue(":REVISION", user.REVISION);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
    
                cmd.CommandText = "insert into Prop_detail(Tdc_no,Tdc_property) values(@tdN,@tdProp)";
                foreach (WireDimDetail wireDimDetail in user.WireDimDetails)
                {
                    cmd.Parameters.Clear();
                    var stringwriter = new System.IO.StringWriter();
                    var serializer = new System.Xml.Serialization.XmlSerializer(wireDimDetail.GetType());
                    serializer.Serialize(stringwriter, wireDimDetail);
    
                    cmd.Parameters.AddWithValue("@tdN", user.TDC_NO);
                    cmd.Parameters.AddWithValue("@tdProp", stringwriter.ToString());
                    cmd.ExecuteNonQuery();
                }
    
                con.Close();
            }
        }
    }
