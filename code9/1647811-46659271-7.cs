    public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    
    			DataTable dt = new DataTable("main");
    			dt.Columns.Add("column_one", typeof(string));
    			dt.Columns.Add("column_two", typeof(string));
    			dt.Columns.Add("column_three", typeof(string));
    			dt.Columns.Add("column_four", typeof(string));
    			dt.Columns.Add("column_five", typeof(string));
    			dgv.DataSource = dt;
    			addAnyRow();
    		}
    
    		public void addAnyRow() {
    			var dt = (DataTable)dgv.DataSource;
    			var row = dt.NewRow();
    			row["column_one"] = "1";
	            row["column_two"] = "2";
		    	row["column_three"] = "3";
		    	row["column_four"] = "4";
		     	row["column_five"] = "5";
		    	dt.Rows.Add(row);
		}
    }
