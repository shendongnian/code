    public static string SetGaranties( List<int> CODE_GARANTIES,  string NUMERO_POLICE, string CODE_BRANCHE, int CODE_SOUS_BRANCHE)
    {
        string MSG_ACQUITEMENT = string.Empty;
        DbCommand com = GenericData.CreateCommand(GenericData.carte_CarteVie_dbProviderName, GenericData.Carte_CarteVie_dbConnectionString);
        com.CommandText = "SetGaranties";
        com.CommandType = CommandType.StoredProcedure;
        // These parameter's values don't change, set it once
        com.Parameters.Add("@NUMERO_POLICE", SqlDbType.VarChar).Value = NUMERO_POLICE;
        com.Parameters.Add("@CODE_BRANCHE",SqlDbType.VarChar).Value = CODE_BRANCHE;
        com.Parameters.Add("@CODE_SOUS_BRANCHE", SqlDbType.Int).Value = CODE_SOUS_BRANCHE;
        // This parameter's value changes inside the loop
        com.Parameters.Add("@CODE_GARANTIE",SqlDbType.Int);
        com.Connection.Open();
        foreach (int CODE_GARANTIE in CODE_GARANTIES)
        {
            com.Parameters["@CODE_GARANTIE"].Value = CODE_GARANTIE;
            com.ExecuteNonQuery();
        }
        com.Connection.Close();                     
    }
