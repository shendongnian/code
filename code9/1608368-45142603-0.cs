            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            ArrayList list1 = new ArrayList(); //{ "C-C", "C-O", "Absence composant", "Mauvaise valeur", "Mauvais sens", "Mauvais composant" };
            list1.Add("C-C");
            list1.Add("C-O");
            
            combo.DataSource = list1;
            combo.HeaderText = "FaultCodeByOp";
            combo.DataPropertyName = "FaultCodeByOp";
            
            dataGridView1.Columns.AddRange(combo); 
