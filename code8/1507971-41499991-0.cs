        con = new SqlConnection("Data Source = LENOVO; Initial Catalog = MainData; Integrated Security = True");
        con.Open();
        string CheckID = "select StaffID from PersonsData where StaffID='" + txtStaffID.Text + "'";
        cm = new SqlCommand(CheckID);
        cm.Connection = con; //Assign connection to command
