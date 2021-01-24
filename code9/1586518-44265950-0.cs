    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            tbID.Text = row.Cells[0].Value.ToString();
            tbIme.Text = row.Cells[1].Value.ToString();
            tbPrezime.Text = row.Cells[2].Value.ToString();
            tbAdresa.Text = row.Cells[3].Value.ToString();
            tbTelefon.Text = row.Cells[4].Value.ToString();
            if (row.Cells[5].Value.ToString() == "0")
            {
                cbPol.SelectedIndex = 0;
            }
            else
            {
                cbPol.SelectedIndex = 1;
            }
            dtbDatumRodjenja.Value = Convert.ToDateTime(row.Cells[6].Value.ToString());
            pacijent = new Pacijent(tbID.Text, tbIme.Text, tbPrezime.Text, tbAdresa.Text, tbTelefon.Text, cbPol.SelectedIndex, dtbDatumRodjenja.Value.Date.ToShortDateString());
        }
            
    }
    private void btnAzuriraj_Click(object sender, EventArgs e)
    {
            
        //pacijent = new Pacijent(tbID.Text, tbIme.Text, tbPrezime.Text, tbAdresa.Text, tbTelefon.Text, cbPol.SelectedIndex, dtbDatumRodjenja.Value.Date.ToShortDateString());
        pacijent.Id = tbID.Text;
        pacijent.Ime = tbIme.Text;
        pacijent.Prezime = tbPrezime.Text;
        pacijent.Adresa = tbAdresa.Text;
        pacijent.Pol = cbPol.SelectedIndex;
        pacijent.DatumRodjenja = dtbDatumRodjenja.Value.Date.ToShortDateString();
        try
        {
            konekcija.Open();
            using (SqlCommand sql = new SqlCommand("UPDATE pacijent SET ime=@Ime, prezime=@Prezime, adresa=@Adresa, telefon=@Telefon, pol=@Pol, datumRodjenja=@DatumRodjenja WHERE id=@ID", konekcija))
            {
                sql.Parameters.Add(new SqlParameter("Ime", pacijent.Ime));
                sql.Parameters.Add(new SqlParameter("Prezime", pacijent.Prezime));
                sql.Parameters.Add(new SqlParameter("Adresa", pacijent.Adresa));
                sql.Parameters.Add(new SqlParameter("Telefon", pacijent.Telefon));
                sql.Parameters.Add(new SqlParameter("Pol", pacijent.Pol));
                sql.Parameters.Add(new SqlParameter("DatumRodjenja", pacijent.DatumRodjenja));
                sql.Parameters.Add(new SqlParameter("ID", pacijent.Id));
                sql.ExecuteNonQuery();
                ocistiPodatke();
                ucitajListuPacijenata();
                MessageBox.Show("Podaci o pacijentu " + pacijent.Ime + " " + pacijent.Prezime + " su uspesno azurirani.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            konekcija.Close();
        }
    }
