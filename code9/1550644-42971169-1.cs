    public partial class Form1 : Form
    {
    	//variable for "remembering" subItem on which tooltip is shown
    	ListViewItem.ListViewSubItem selectedListViewSubItem = new ListViewItem.ListViewSubItem();
    
    	public Form1()
    	{
    		InitializeComponent();
    
    	} 
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    		//subscribe to events - when mouse leaves listview and when mouse is moved over listview
    		listView1.MouseLeave += ListView1_MouseLeave;
    		listView1.MouseMove += ListView1_MouseMove;
    		
    	}
    
    	private void ListView1_MouseMove(object sender, MouseEventArgs e)
    	{
    		//using current location, check what is under mouse
    		var info = listView1.HitTest(e.Location);
    		
    		//if any subitem is selected AND subitem differs from last one
    		if (info.SubItem != null  && info.SubItem != selectedListViewSubItem)
    		{
    			//remember current subitem
    			selectedListViewSubItem = info.SubItem;
    			//set tooltip's new location to the bottom right of mouse pointer
    			Point calculatedLocation = new Point(e.X + 20, e.Y + 20);
    			//show tooltip - with subitem text, on this window, on calculated location and hold it there for 3 seconds.
    			toolTip1.Show(info.SubItem.Text, listView1, calculatedLocation, 3000);
    		}
    	}
    
    	private void ListView1_MouseLeave(object sender, EventArgs e)
    	{
    		//hide tooltip
    		this.toolTip1.Hide(this);
    	}
	
