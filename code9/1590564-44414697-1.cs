        private void btnShowCausali_Click(object sender, EventArgs e)
        {
             DataGridView Dati = new DataGridView();
            Dati.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dati.Location = new System.Drawing.Point(120, 40);
            Dati.Name = "Dati";
            Dati.RowTemplate.Height = 24;
            Dati.Size = new System.Drawing.Size(979, 458);
            Dati.TabIndex = 1;
            Dati.Visible = true;
            Dati.Columns.Add("id", "ID");
            Dati.Columns.Add("causaliname", "Nome Causale");
            Dati.Columns.Add("Identificationcode", "Codice Identificativo");
            Dati.Columns.Add("expired", "Data di Scadenza");
            grpDatore.Controls.Add(Dati); // DataGridView added to grpDatore, not form. Make shure grpDatore is visible.
        }
