    public partial class Form1 : Form
    	{
    		public Form1()
    		{
    			InitializeComponent();
    			dgv.Columns.Add("cell_one", "Cell 1");
    			dgv.Columns.Add("cell_two", "Cell 2");
    			dgv.Columns.Add("cell_three", "Cell 3");
    			dgv.Columns.Add("cell_four", "Cell 4");
    			dgv.Columns.Add("cell_five", "Cell 5");
    			addNASDestination(new string[] { "1", "3", "4", "5" });
    		}
    
    		public void addNASDestination(string[] info)
    		{
    			/*string[0] = Name
    			* string[1] = Path
    			* string[2] = Username
    			* string[3] = Password - Needs to be passed to XML encrypted. Not displayed in the table at all
    			*/
    			dgv.Rows.Add(info[0], "NAS", info[1], info[2], info[3]);
    			//checkTableRowCount();
    		}
    	}
