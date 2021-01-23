    // Extract a method (or even a class): do not mix UI and business logic/storage
    // Just RDBMS logic: no UI controls or something at all
    private static void CoreInsertFisier(string idFisier, nume, idFolder) {
      // Do not hardcode the connection string, but read it (from settings)
      // wrap IDisposable into using
      using (SqlConnection con = new SqlConnection(ConnectionStringHere)) {
        con.Open();
        // Make sql readable (use verbatim strings @"...")
        // Make sql parameterized 
        string sql = 
          @"INSERT INTO Fisier (
               idFisier, 
               Nume, 
               idFolder)
            VALUES (
               @prm_idFisier, 
               @prm_Nume, 
               @prm_idFolder)";
         // wrap IDisposable into using
         using (SqlCommand cmd = new SqlCommand(sql, con)) {
           // Parameters.Add(...) is a better choice, but you have to know fields' types
           cmd.Parameters.AddWithValue("@prm_idFisier", idFisier); 
           cmd.Parameters.AddWithValue("@prm_Nume", nume);
           cmd.Parameters.AddWithValue("@prm_idFolder", idFolder); 
           cmd.ExecuteNonQuery(); 
         }
      }
    }
    ...
 
    private void button1_Click(object sender, EventArgs e) {
      // UI: just one call - please insert these three textbox into db
      CoreInsertFisier(idFis.Text, numeFis.Text, idFoldFis.Text);
    }
