    public class StateInfo
	{
		public string State {get;set;}
		public string SiteAdd {get;set;}
		public string Latitude {get;set;}
		public string Longtiude {get;set;}
	}
	public static StateInfo GETSTATE_SAP(string SAP)
    {
        var result = new StateInfo();
        try
        {
            OracleConnection Oraconn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionStringAPPSAPID"].ConnectionString);
            Oraconn.Open();
            OracleCommand cmd = new OracleCommand("Select STATE, SITE_NAME, SITE_ADDRESS, latitude, longitude from R4G_OSP.UBR where SAP_ID = '" + SAP + "'", Oraconn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dtSap = new DataTable();
            da.Fill(dtSap);
            result.State = Convert.ToString(dtSap.Rows[0][0]);
            result.SiteAdd = Convert.ToString(dtSap.Rows[0][0]);
            result.Latitude = Convert.ToString(dtSap.Rows[0][0]);
            result.Longtiude = Convert.ToString(dtSap.Rows[0][0]);
        }
        catch (Exception)   // <--- I'll explain below..
        {
            return null;
        }
        return result;
    }
