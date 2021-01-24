    public partial class MainForm : Form {
		
		public MainForm() {
		    InitializeComponent();
		    DataTable dt = new DataTable();
		    dt.Columns.Add(new DataColumn("column1", typeof(string)));
		    dt.Columns.Add(new DataColumn("column2", typeof(bool)));
		    
		    dt.Rows.Add("row1", 1);
		    dt.Rows.Add("row2", 0);
		    dt.Rows.Add("row3", 1);
		    dt.Rows.Add("row4", 1);
		    dt.Rows.Add("row5", 0);
		    
		    DataView dv = dt.AsDataView();
		    
		    dataGridView1.DataSource = dv;
		}
		
		private void filterDGV(string rowFilter)
		{
			DataView dv = (DataView)dataGridView1.DataSource;
			dv.RowFilter = rowFilter;
		}
		
		private void FilterToCheckedRows_Click(object sender, EventArgs e)
		{
			filterDGV("column2 = 1");
		}
		
		private void FilterToUncheckedRows_Click(object sender, EventArgs e)
		{
			filterDGV("column2 = 0");
		}
	}
