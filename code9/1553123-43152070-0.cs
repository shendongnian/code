    using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString(updatedFeature.Environment))
   
    sqlConnection.Open();
  
    using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
    {
        sqlCommand.CommandType = CommandType.StoredProcedure;
        sqlCommand.CommandText = "usp_UpdateFeature";
        sqlCommand.Parameters.AddWithValue("@FeatureName", updatedFeature.FeatureName);
        sqlCommand.Parameters.AddWithValue("@FeatureID", updatedFeature.FeatureID);
        sqlCommand.Parameters.AddWithValue("@FeatureDescription", updatedFeature.Description);
        sqlCommand.Parameters.AddWithValue("@FieldName", updatedFeature.FieldName);
        sqlCommand.Parameters.AddWithValue("@OnOffSwitch", updatedFeature.IsOn);
        sqlCommand.Parameters.AddWithValue("@ChannelID", updatedFeature.ChannelID);
        sqlCommand.Parameters.AddWithValue("@ProductID", updatedFeature.ProductID);                
        int numberOfRowsChanged =  sqlCommand.ExecuteNonQuery();
    }
