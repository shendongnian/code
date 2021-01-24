     private void btnUpdate_Click(object sender, EventArgs e)
            {
                string wartosc = "UPDATE tblStudent17 SET Imie = @imie, Nazwisko = @nazwisko, Dane_Kontaktowe = @danekontaktowe WHERE idOsoby= @idOsoby";
                using (connection = new SqlConnection(string_polaczeniowy))
                {
                    connection.Open();
                    SqlCommand xquery = new SqlCommand(wartosc, connection);
                    xquery.Parameters.AddWithValue("@imie", txtImie.Text);
                    xquery.Parameters.AddWithValue("@nazwisko", txtNazwisko.Text);
                    xquery.Parameters.AddWithValue("@danekontaktowe", rtbDaneKontaktowe.Text);
                    xquery.Parameters.AddWithValue("@idOsoby", tbIdOsoby.Text);
                    SqlDataAdapter xdata = new SqlDataAdapter(xquery);
                    xdata.Fill(dtsTabelaTestowa);
                }
    
                wypelnijTabeleDanymi();
            }
    
    
     private void wypelnijTabeleDanymi()
            {
                using (connection = new SqlConnection(string_polaczeniowy))
                {
                    connection.Open();
                    SqlCommand xquery = new SqlCommand("select * from tblStudent17", connection);
                    SqlDataAdapter xdata = new SqlDataAdapter(xquery);
                    dtsTabelaTestowa.Clear();
                    xdata.Fill(dtsTabelaTestowa);
                    dgTabelaTestowa.DataSource = dtsTabelaTestowa.Tables[0];
                    dgTabelaTestowa.Refresh();
                  
                }
            }
