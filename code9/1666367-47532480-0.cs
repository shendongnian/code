    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    		loadDataIntoGridView1();
    	}
    
    	public DataTable tblFrom { get; set; }
    	public DataTable tblTo { get; set; }
    	private void loadDataIntoGridView1()
    	{
    		tblFrom = new DataTable();
    		tblFrom.Columns.Add("Col1", typeof(string));
    		tblFrom.Columns.Add("Col2", typeof(string));
    
    		tblTo = tblFrom.Clone();
    
    		DataRow tmp;
    		while (tblFrom.Rows.Count < 20)
    		{
    			tmp = tblFrom.NewRow();
    			tmp["Col1"] = "my row " + tblFrom.Rows.Count;
    			tmp["Col2"] = "testing";
    			tblFrom.Rows.Add(tmp);
    		} 
    
    		dataGridView1.AutoGenerateColumns = true;
    		dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    		dataGridView2.AutoGenerateColumns = true;
    		dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    		dataGridView1.DataSource = tblFrom;
    		dataGridView2.DataSource = tblTo;
    	}
    
    	private void button1_Click(object sender, System.EventArgs e)
    	{
    		// if no ROWS selected, get out.
    		if (dataGridView1.SelectedRows.Count == 0)
    			return;
    
    		foreach( DataGridViewRow vr in dataGridView1.SelectedRows)
    		{
    			var currentRow = ((DataRowView)vr.DataBoundItem).Row;
    			((DataTable)dataGridView2.DataSource).ImportRow(currentRow);
    
    			//this will remove the rows you have selected from dataGridView1
    			dataGridView1.Rows.RemoveAt(vr.Index);
    		}
    	}
    }
