    namespace StackOverflow___46658777
    {
    	public static class Global
    	{
    		public static DataGridView DestinationTable;
    	}
    
    	public partial class Form1 : Form
    	{
    		public Form1(bool dataTableOrManual = false)
    		{
    			InitializeComponent();
    			Global.DestinationTable = dgv;
    
    			if (dataTableOrManual) {
    				var dt = new DataTable("main");
    				dt.Columns.Add("column_one", typeof(string));
    				dt.Columns.Add("column_two", typeof(string));
    				dt.Columns.Add("column_three", typeof(string));
    				dt.Columns.Add("column_four", typeof(string));
    				dt.Columns.Add("column_five", typeof(string));
    				dgv.DataSource = dt;
    				new TAutoCheck().AddAnyRow();
    				new TAutoCheck().AddAnyRow();
    				new TAutoCheck().AddAnyRow();
    			} else {
    				dgv.Columns.Add("cell_one", "Cell 1");
    				dgv.Columns.Add("cell_two", "Cell 2");
    				dgv.Columns.Add("cell_three", "Cell 3");
    				dgv.Columns.Add("cell_four", "Cell 4");
    				dgv.Columns.Add("cell_five", "Cell 5");
    				new TAutoCheck().AddNASDestination(new string[] { "1", "3", "4", "5" });
    			}
    		}
    	}
    
    	public class TDialog : Form
    	{
    		public TDialog()
    		{
    			//anyButton.Click += validateRequest;
    		}
    
    		void validateRequest(object sender, EventArgs args)
    		{
    			new TAutoCheck().AddNASDestination(new string[] { "your", "validated", "strings", "are", "here" });
    		}
    	}
    
    	public class TAutoCheck
    	{
    		public TAutoCheck() { }
    
    		public void AddAnyRow()
    		{
    			var dt = (DataTable)Global.DestinationTable.DataSource;
    			var row = dt.NewRow();
    			row["column_one"] = "1";
    			row["column_two"] = "2";
    			row["column_three"] = "3";
    			row["column_four"] = "4";
    			row["column_five"] = "5";
    			dt.Rows.Add(row);
    		}
    		
    		public void AddNASDestination(string[] info)
    		{
    			/*string[0] = Name
    			* string[1] = Path
    			* string[2] = Username
    			* string[3] = Password - Needs to be passed to XML encrypted. Not displayed in the table at all
    			*/
    			Global.DestinationTable.Rows.Add(info[0], "NAS", info[1], info[2], info[3]);
    			//checkTableRowCount();
    		}
    	}
    }
