    SqlCommand sc = new SqlCommand("select SubdivisionName,Countryname from dbo.Locations where CountryName = '" + comboBox1.Text + "'", conn);
    comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
    comboBox2.FormattingEnabled = true;
    comboBox2.ValueMember = "Countryname";
    comboBox2.DisplayMember = "Countryname";
    comboBox2.DataSource = dt;
