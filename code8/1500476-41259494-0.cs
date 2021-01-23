      SqlDataAdapter sda = new SqlDataAdapter("SELECT T_Artikel.ArtikelBezeichnung, T_Artikel.IDArtikel AS Expr1 FROM T_Benutzer_Artikel INNER JOIN T_Artikel ON T_Benutzer_Artikel.IDArtikel = T_Artikel.IDArtikel WHERE(T_Benutzer_Artikel.IDBenutzer =" + lokIDBenutzer + ")", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            iDArtikelDataGridViewComboBoxColumn.DataSource = dt;
            iDArtikelDataGridViewComboBoxColumn.ValueMember = "Expr1";
            iDArtikelDataGridViewComboBoxColumn.DisplayMember = "ArtikelBezeichnung";
