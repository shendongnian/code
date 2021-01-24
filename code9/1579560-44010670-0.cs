    public int Save() {
        int ReturnValue;
        string sqlQuery = "INSERT INTO Recipe_Drug (id_recipe, id_drug, quantity, remark) VALUES (@idRecipe, @idDrug, @quantity, @remark)";
        using (SqlConnection conn = new SqlConnection(ConnectionString)) {
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn)) {
                cmd.Paramaters.AddWithValue("@idRecipe", Recipe.IdRecipe);
                cmd.Paramaters.AddWithValue("@idDrug", Drug.IdDrug);
                cmd.Paramaters.AddWithValue("@quantity", Quantity);
                cmd.Paramaters.AddWithValue("@remark", Remark);
                try {
                    conn.Open();
                    ReturnValue = cmd.ExecuteNonQuery();
                }
                catch(Exception ex) {
                    ReturnValue = -1;
                    // your error handling
                }
                finally { conn.Close(); }
            }
        }
        return ReturnValue;
    }                    
