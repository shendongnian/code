    public partial class MainForm : Form {
		
		public MainForm() {
		    InitializeComponent();
		    DataGridView dgv = new DataGridView();
		    dgv.Columns.Add("columnName", "columnName");
		    dgv.AllowUserToAddRows = false;
		    
		    dgv.Rows.Add(21.0);
		    dgv.Rows.Add(15.0);
		    dgv.Rows.Add(20.0);
		    dgv.Rows.Add(25.0);
		    dgv.Rows.Add(30.12354122);
		    
		    this.Controls.Add(dgv);
		    
		    ShowInteraction(dgv, "columnName");
		}
	        
        public void ShowInteraction(DataGridView dv, string columnName) {
        	List<double> values = dv.Rows.Cast<DataGridViewRow>().Select(row => Convert.ToDouble(row.Cells[columnName].Value)).ToList();
		    double Max = values.Max();
		    double Min = values.Min();
	        
	        foreach (DataGridViewRow row in dv.Rows)
	        {
	        	if (row.Cells[columnName].Value != null)
	            {
	        		double cellValue = Convert.ToDouble(row.Cells[columnName].Value);
	        		var cell = row.Cells[columnName];
	        		if (cellValue == Min)
	                {
	                    cell.Value = "L";
	                }
	                else if (cellValue == Max)
	                {
	                    cell.Value = "H";
	                }
	                else if (cellValue < Max && cellValue > Min)
	                {
	                    cell.Value = "M";
	                }
	                else if (cellValue == 0)
	                {
	                    cell.Value = "N";
	                }
	                else
	                {
	                    cell.Value = "L";
	                }
	            }
	        }
		}
	}
