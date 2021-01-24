    if (bunifuCheckbox1.Checked == true)
    {
        string sql = "Insert into clienti_fizici(nume, prenume, email, telefon, adresa, data_nasterii, data_ora, CNP, sex, judetprovenienta, temperamentclient, provenientaclient, descriere, numeagent) " + 
                     "SELECT @nume, @prenume, @email, @telefon, @adresa, @data_nasterii, @data_ora, @CNP, @sex, @judetprovenienta, @temperamentclient, @provenientaclient, @descriere, CONCAT(nume,' ',prenume) " + 
                     "FROM echipa where email = @EMAIL";
        // Note: SqlConnection should be opened for the shortest time possible - the using statement close and dispose it when done.
        using(var con = new SqlConnection(connectionString))
        {
            // SqlCommand is also an IDisposable and should be disposed when done.
            using(var cmd = new SqlCommand(sql, con)
            {
            cmd.Parameters.Add("@nume", SqlDbType.NVarChar).Value = bunifuMaterialTextbox1.Text;
            cmd.Parameters.Add("@prenume", SqlDbType.NVarChar).Value = bunifuMaterialTextbox2.Text;
            //... Add the rest of the parameters here...
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = loginform.Email;
            // Why is this here? MessageBox.Show("Datele au fost introduse in baza de date !");
            con.Open();
            cmd.ExecuteNonQuery();
            }
        }
    }
