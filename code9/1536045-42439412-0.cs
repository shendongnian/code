       TextBox newTxt = new TextBox();
       ComboBox newcombo = new ComboBox();
        // Add Textbox
        newTxt.Text = col.Field<String>("ColumnName");
        newTxt.Name = col.Field<String>("ColumnName");
        newTxt.Width = 110;
        // Add Combobox
        newcombo.Items.Add(myReader.GetDataTypeName(n));
        newcombo.Items.Add("INT");
        newcombo.SelectedItem = myReader.GetDataTypeName(n);
        newcombo.Name = myReader.GetDataTypeName(n);
        newcombo.Width = 90;
       controls.Add(newcombo);
       controls.Add(newTxt);
     
     var controls = sp.Children.OfType<UserControl>().ToList();
     foreach (var control in controls )
     {
                var selected = "i dont know";
                config conf = new config();
                db_connection();
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "ALTER TABLE firmenkunden CHANGE COLUMN " + control.Name + " " + control .Text + " " + selected  + " NOT NULL";
                MessageBox.Show(cmd.CommandText);
     }
