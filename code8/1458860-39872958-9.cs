	public class MainForm : Form
	{
		private ColorListControl listView1;
		public MainForm()
		{
			InitializeComponent();
			MyEntity entity = new MyEntity { SelectedColors = Color.Blue | Color.White };
			listView1.DataBindings.Add( nameof( listView1.SelectedColor ), entity, nameof( entity.SelectedColors ) );
		}
		private void InitializeComponent()
		{
			this.listView1 = new ColorListControl();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Location = new System.Drawing.Point(16, 16);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(200, 128);
			this.listView1.TabIndex = 0;
			this.listView1.SelectedColorChanged += new System.EventHandler(this.listView1_SelectedColorChanged);
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(318, 189);
			this.Controls.Add(this.listView1);
			this.Name = "MainForm";
			this.Text = "Form";
			this.ResumeLayout(false);
		}
		private void listView1_SelectedColorChanged( object sender, EventArgs e )
		{
			this.Text = listView1.SelectedColor.ToString();
		}
	}
