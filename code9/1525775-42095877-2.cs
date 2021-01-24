    public partial class MainForm : Form {
		
		public MainForm() {
		    InitializeComponent();
		    DataTable dt = new DataTable();
            // change string to whatever your object type is
		    dt.Columns.Add(new DataColumn("object column", typeof(string)));
		    dt.Columns.Add(new DataColumn("CheckBoxColumn", typeof(bool)));
		    
		    dt.Rows.Add("row1", 1);
	        dt.Rows.Add("row2", 0);
	        dt.Rows.Add("row3", 1);
	        dt.Rows.Add("row4", 1);
	        dt.Rows.Add("row5", 0);
		    
	        BindingSource binding = new BindingSource();
	        binding.DataSource = dt;
	        
		    dataGridView1.DataSource = binding;
		}
		
		private void filterDGV(string rowFilter)
		{
			BindingSource source = (BindingSource)dataGridView1.DataSource;
			source.Filter = rowFilter;
		}
		
		private void FilterToCheckedRows_Click(object sender, EventArgs e)
		{
			filterDGV("CheckBoxColumn = 1");
		}
		
		private void FilterToUncheckedRows_Click(object sender, EventArgs e)
		{
			filterDGV("CheckBoxColumn = 0");
		}
	}
