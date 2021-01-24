            BindingSource bs = new BindingSource();
    
            private DataTable GetDataTable()
            {
               //Please consider checking the populating data function from errors, or post your code to help you with. 
                DataTable dt =_myFunction.Select_New_Inserted_Info(_lDataParameter).Tables[0];
    
                return dt;
            }
            private void formList_Load(object sender, EventArgs e)
            {
                DataTable _dt = GetDataTable();
    
                bs.DataSource = _dt;
                gridControl1.DataSource = bs;
    
                timer1.Interval = 5000;
                timer1.Start();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                DataTable _dt = GetDataTable();
    
                bs.DataSource = _dt;
                gridControl1.DataSource = bs;
            }
