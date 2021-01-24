     public MyClass string GETSTATE_SAP(string SAP)
        {
            MyClass myObj = new MyClass();
            string strState = "";
            string strSiteAdd = "";
            string strLatitude = "";
            string strLongtiude = "";
            try
            {
                OracleConnection Oraconn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionStringAPPSAPID"].ConnectionString);
                Oraconn.Open();
                OracleCommand cmd = new OracleCommand("Select STATE, SITE_NAME, SITE_ADDRESS, latitude, longitude from R4G_OSP.UBR where SAP_ID = '" + SAP + "'", Oraconn);
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                DataTable dtSap = new DataTable();
                da.Fill(dtSap);
    
                myObj.strState = Convert.ToString(dtSap.Rows[0][0]);
                myObj.strSiteAdd = Convert.ToString(dtSap.Rows[0][0]);
                myObj.strLatitude = Convert.ToString(dtSap.Rows[0][0]);
                myObj.strLongtiude = Convert.ToString(dtSap.Rows[0][0]);
            }
            catch (Exception)
            {
            }
            return myObj;
        }
        public class MyClass
        {
            public string strState { get; set; }
            public string strSiteAdd { get; set; }
            public string strLatitude { get; set; }
            public string strLongtiude { get; set; }
            
          
        }
