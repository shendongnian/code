    private void button1_Click_1(object sender, EventArgs e)
            {
                string Mnuf = dgMasterGridView.SelectedRows[0].Cells[1].Value + string.Empty;
                string ML = dgMasterGridView.SelectedRows[0].Cells[2].Value + string.Empty;
                string PD = dgMasterGridView.SelectedRows[0].Cells[3].Value + string.Empty;
                string WST = dgMasterGridView.SelectedRows[0].Cells[4].Value + string.Empty;
                string OD = dgMasterGridView.SelectedRows[0].Cells[5].Value + string.Empty;
                string WT = dgMasterGridView.SelectedRows[0].Cells[6].Value + string.Empty;
                string Coat = dgMasterGridView.SelectedRows[0].Cells[7].Value + string.Empty;
                string Grad = dgMasterGridView.SelectedRows[0].Cells[8].Value + string.Empty;
                string Heat = dgMasterGridView.SelectedRows[0].Cells[9].Value + string.Empty;
                string Ansi = dgMasterGridView.SelectedRows[0].Cells[10].Value + string.Empty;
                string PO = dgMasterGridView.SelectedRows[0].Cells[11].Value + string.Empty;
                string STD = dgMasterGridView.SelectedRows[0].Cells[12].Value + string.Empty;
    
                // Connection to DB
                SqlConnection con = new SqlConnection();
                con.ConnectionString = (@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database;Integrated Security=True");
                //Insert Query
                string insertquery = "INSERT INTO dbo.[myTable] ([Manufacturer], [Mill Location], [Product Description], [Weld Seam Type], [Outer Dimension], [Wall Thickness], [Coating], [Grade], [Heat], [ANSI/ASME], [Purchase Order], [Standard]) VALUES(@Manufacturer,@MillLocation,@ProductDescription,@WeldSeamType,@OuterDimension,@WallThickness,@Coating,@Grade,@Heat,@ANSIASME,@PurchaseOrder,@Standard)";
    
                SqlCommand cmd = new SqlCommand(insertquery, con);
                //open connection
                con.Open();
    
                //Parameters
                cmd.Parameters.AddWithValue("@Manufacturer", Mnuf);
                cmd.Parameters.AddWithValue("@MillLocation", ML);
                cmd.Parameters.AddWithValue("@ProductDescription", PD);
                cmd.Parameters.AddWithValue("@WeldSeamType", WST);
                cmd.Parameters.AddWithValue("@OuterDimension", OD);
                cmd.Parameters.AddWithValue("@WallThickness", WT);
                cmd.Parameters.AddWithValue("@Coating", Coat);
                cmd.Parameters.AddWithValue("@Grade", Grad);
                cmd.Parameters.AddWithValue("@Heat", Heat);
                cmd.Parameters.AddWithValue("@ANSIASME", Ansi);
                cmd.Parameters.AddWithValue("@PurchaseOrder", PO);
                cmd.Parameters.AddWithValue("@Standard", STD);
    
                //execute
                cmd.ExecuteNonQuery();
    
                MessageBox.Show("Information has been submitted");
    
                //close connection
                con.Close();
    
               ;
            }
        }
