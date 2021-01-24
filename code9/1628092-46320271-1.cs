	public partial class MDIChildForm : Form
	{
		public String TitleText 
		{
			get { return this.Text; }
			set { this.Text = value; }
		}
		MainForm parent = null;
		public MDIChildForm()
		{
			InitializeComponent();
			this.ShowIcon = false;
		}
		private void MDIChildForm_LocationChanged(object sender, EventArgs e)
		{
			if (parent != null)
				parent.ShifTheChild(this);
		}
		private void MDIChildForm_Load(object sender, EventArgs e)
		{
			parent = this.MdiParent as MainForm;
		}
	}
