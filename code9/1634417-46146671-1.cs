            private void DetayButton_Click(object sender, RoutedEventArgs e)
        {
            DetayWindow pencere = new DetayWindow();
            string sorgu = "Select * From Gayrimenkul";
            DataSet dataSet = new DataSet();
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(sorgu, baglanti);
            dataAdapter.Fill(dataSet);
            int i = dataGrid1.SelectedIndex;
            string veribaslik = dataSet.Tables[0].Rows[i]["baslik"].ToString();
            string veriyazi = dataSet.Tables[0].Rows[i]["yazi"].ToString();
            string veritarih = dataSet.Tables[0].Rows[i]["tarih"].ToString();
            string verimevkii = dataSet.Tables[0].Rows[i]["mevkii"].ToString();
            string verimetrekare = dataSet.Tables[0].Rows[i]["metrekare"].ToString();
            string veritur = dataSet.Tables[0].Rows[i]["tur"].ToString();
            string veriid = dataSet.Tables[0].Rows[i]["id"].ToString();
            pencere.baslik = veribaslik;
            pencere.yazi = veriyazi;
            pencere.tarih = veritarih;
            pencere.mevkii = verimevkii;
            pencere.metrekare = verimetrekare;
            pencere.tur = veritur;
            pencere.id = veriid;
            pencere.ShowDialog();
        }
