    public class StateInfo
	{
		public string State {get;set;}
		public string SiteAdd {get;set;}
		public string Latitude {get;set;}
		public string Longtiude {get;set;}
	}
	public static StateInfo GETSTATE_SAP(string SAP)
    {
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
            strState = Convert.ToString(dtSap.Rows[0][0]);
            strSiteAdd = Convert.ToString(dtSap.Rows[0][0]);
            strLatitude = Convert.ToString(dtSap.Rows[0][0]);
            strLongtiude = Convert.ToString(dtSap.Rows[0][0]);
        }
        catch (Exception)
        {
        }
        return new StateInfo { State = strState, SiteAdd = strSiteAdd, Latitude = strLatitude, Longtiude = strLongtiude };
    }
