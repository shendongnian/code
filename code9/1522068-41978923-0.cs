    public class Form1 : Form
    {
    	public TextBox textBox1 { get; set; }
    	
    	public Button button1 { get; set; }
    	
    	private void button1_Click(object sender, EventArgs e)
    	{
    		var form = new Form2();
    		form.Show();
    		textBox1.Text = form.val;
    		//do your sql stuff here
    	}
    }
    
    public class Form2 : Form
    {
    	public DataGridView datagriview1 { get; set; }
    	
    	public string val { get; set; }
    	
    	private void datagriview1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    	{
    		if (e.RowIndex > -1)
    			val = datagriview1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
    		Close();
    	}
    }
