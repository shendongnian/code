	public class MainForm : Form
	{
		private CheckedListBox checkedListBox;
		private TableLayoutPanel tableLayoutPanel;
		public MainForm()
		{
			InitializeComponent();
			//Fill checkedListBox and create controls
			for( int i = 0; i <= 5; i++ )
			{
				checkedListBox.Items.Add( i.ToString() );
				Label lbl = new Label()
				{
					Name = "lbl" + i,
					Text = "Label " + i,
					Visible = false
				};
				NumericUpDown num = new NumericUpDown()
				{
					Name = "num" + i,
					Value = i,
					Visible = false
				};
				tableLayoutPanel.Controls.Add( lbl, 0, i );
				tableLayoutPanel.Controls.Add( num, 1, i );
			}
		}
		private void checkedListBox_ItemCheck( object sender, ItemCheckEventArgs e )
		{
			if( e.NewValue == CheckState.Checked )
			{
				tableLayoutPanel.Controls["lbl" + e.Index].Visible = true;
				tableLayoutPanel.Controls["num" + e.Index].Visible = true;
			}
			else
			{
				tableLayoutPanel.Controls["lbl" + e.Index].Visible = false;
				((NumericUpDown)tableLayoutPanel.Controls["num" + e.Index]).Value = 0M;
			}
		}
		private void InitializeComponent()
		{
			this.checkedListBox = new System.Windows.Forms.CheckedListBox();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.SuspendLayout();
			// 
			// checkedListBox
			// 
			this.checkedListBox.Location = new System.Drawing.Point(8, 8);
			this.checkedListBox.Name = "checkedListBox";
			this.checkedListBox.Size = new System.Drawing.Size(200, 100);
			this.checkedListBox.TabIndex = 1;
			this.checkedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox_ItemCheck);
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.AutoScroll = true;
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel.Location = new System.Drawing.Point(8, 112);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel.TabIndex = 2;
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(223, 227);
			this.Controls.Add(this.tableLayoutPanel);
			this.Controls.Add(this.checkedListBox);
			this.Name = "MainForm";
			this.ResumeLayout(false);
		}
	}
