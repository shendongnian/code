        public static bool GETSTATE_SAP(string SAP, out string strState, out string strSiteAdd, out string strLatitude, out string strLongtiude)
            {
                strState = string.Empty;
                strSiteAdd = string.Empty;
                strLatitude = string.Empty;
                strLongtiude = string.Empty;
                try
                {
                    OracleConnection Oraconn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionStringAPPSAPID"].ConnectionString);
                    Oraconn.Open();
                    OracleCommand cmd = new OracleCommand("Select STATE, SITE_NAME, SITE_ADDRESS, latitude, longitude from R4G_OSP.UBR where SAP_ID = '" + SAP + "'", Oraconn);
                    OracleDataAdapter da = new OracleDataAdapter(cmd);
                    DataTable dtSap = new DataTable();
                    da.Fill(dtSap);
    if(dtSap.Rows.Count > 0){
                    strState = Convert.ToString(dtSap.Rows[0][0]);
                    strSiteAdd = Convert.ToString(dtSap.Rows[0][0]);
                    strLatitude = Convert.ToString(dtSap.Rows[0][0]);
                    strLongtiude = Convert.ToString(dtSap.Rows[0][0]);
    return true;
    }
                }
                catch (Exception)
                {
                }
                return false;
            }
