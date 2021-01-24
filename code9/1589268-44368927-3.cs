    public static class DatabaseAccess{
    
        private static string ConString = "<SOMECONSTRING>";
        public static void Update_LeadInfo(LeadInfo infoObj){ //Don't mix CamelCase and _ Case Notation
            using (MySqlConnection cn = new MySqlConnection(ConString))
            {
			   MySqlCommand cmd = new MySqlCommand();
			   cmd.Connection = cn;
			   cmd.CommandText = "UPDATE Leads SET CVR = ('" + infoObj.CVR + "'), Firma = ('" + infoObj.Firma + "'), Nummer = ('" + infoObj.Nummer + "'), Addresse = ('" + infoObjAddresse + "'), Postnr = ('" + infoObj.Postnr + "'), Bynavn = ('" + infoObj.By + "'), Noter = ('" + infoObj.Noter + "'), Afholdt = ('" + infoObj.Afholdt + "'), Email = ('" + infoObj.Email + "'), Slut_Dato = ('" + infoObj.SlutDato + "')  WHERE UniqueID = ('" + infoObj.UniqueID + "');";
			   cmd.ExecuteNonQuery();
			   cmd.Dispose();
			   cn.Close();
            }
        }
    }
