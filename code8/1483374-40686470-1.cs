            List<DataItem> t;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            t = new List<DataItem>();
            DataItem t1 = new DataItem() { AMT = 5, STATUS = "LOCKED" };
            DataItem t2 = new DataItem() { AMT = 15, STATUS = "OPEN" };
            DataItem t3 = new DataItem() { AMT = 25, STATUS = "OPEN" };
            DataItem t4 = new DataItem() { AMT = 35, STATUS = "LOCKED" };
            t.Add(t1);
            t.Add(t2);
            t.Add(t3);
            t.Add(t4);
            grid1.DataSource = t;
            grid1.DataBind();
        }
        protected void grid1_UpdateCommand(object sender, DataGridCommandEventArgs e)
        {
            string newAmount = (e.Item.Cells[1].FindControl("txtAmount") as TextBox).Text;
            
            //Update the data source with edited data
            grid1.EditItemIndex = -1;
            //Load Data with updated data
            LoadData();
        }
        protected void grid1_CancelCommand(object sender, DataGridCommandEventArgs e)
        {
            grid1.EditItemIndex = -1; //Bring back the previous state
            LoadData();
        }
        public bool IsRowEditable(string status)
        {
            return !status.Equals("Locked", StringComparison.OrdinalIgnoreCase);
        }
        protected void grid1_EditCommand(object source, DataGridCommandEventArgs e)
        {
            grid1.EditItemIndex = e.Item.ItemIndex;
            LoadData();
        }
        protected void grid1d_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
        }
