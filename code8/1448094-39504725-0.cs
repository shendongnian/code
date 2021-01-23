            //Read Status info from DB
            if(formLoaded)
            {
                SqlDataAdapter SparePartReader = new SqlDataAdapter(SQLSparePartDropbox);
                SparePartReader.Fill(SparePart);
                comboBoxFinJCSpares1.DataSource = SparePart;
                comboBoxFinJCSpares1.DisplayMember = "DisplayMember";
                comboBoxFinJCSpares1.ValueMember = "PartID";
                //Set Combox1 affiliated Cost value to cost textbox
                int ComBo1PartID = (int)comboBoxFinJCSpares1.SelectedValue;
                string CostPrice = (from DataRow dr in SparePart.Rows
                                where (int)dr["PartID"] == ComBo1PartID
                                select (string)dr["PartCost"]).FirstOrDefault();
                textBoxFinJCCost1.Text = CostPrice.ToString();
            }
