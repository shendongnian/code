     void fillcombo()
        {
            
            MySqlConnection con = new MySqlConnection(ConnectionString);
            string com = "SELECT driverFName,driverLName,vehicleID,driverDlNo,driverContact FROM driver";
            MySqlCommand command = new MySqlCommand(com, con);
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            cmbfilter.DisplayMember = "Text";
            cmbfilter.ValueMember = "Value";
            List<ComboboxItem> list = new List<ComboboxItem>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
               
                string C = reader.GetName(i);
                string _name="";
                string _value = "";
                switch (C)
                {
                      case "id":
                        _name= "ID";
                        _value = C;
                            break;
                    
                      case "driverFName":
                            _name = "First Name";
                            _value = C;
                            break;
                      case "driverLName":
                            _name = "Last name";
                            _value = C;
                            break;
                      case "vehicleID":
                            _name = "Vehicle No";
                            _value = C;
                            break;
                      case "driverDlNo":
                            _name = "Licence No";
                            _value = C;
                            break;
                      case "driverContact":
                            _name = "Contact No";
                            _value = C;
                           
                            break;
                }
