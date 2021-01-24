	public partial class WordEditControl : UserControl
	{
		private readonly Regex underscoreRegex = new Regex("(__*)");
		private List<EditableLabel> labels = new List<EditableLabel>();
		public WordEditControl()
		{
			InitializeComponent();
		}
		public void SetQuizText(string text)
		{
			contentPanel.Controls.Clear();
			foreach (string item in underscoreRegex.Split(text))
			{
				var label = new Label
				{
					FlatStyle = FlatStyle.System,
					Padding = new Padding(),
					Margin = new Padding(0, 3, 0, 0),
					TabIndex = 0,
					Text = item,
					BackColor = Color.White,
					TextAlign = ContentAlignment.TopCenter
				};
				if (item.Contains("_"))
				{
					label.ForeColor = Color.Red;
					var edit = new TextBox
					{
						Margin = new Padding()
					};
					labels.Add(new EditableLabel(label, edit));
				}
				contentPanel.Controls.Add(label);
				using (Graphics g = label.CreateGraphics())
				{
					SizeF textSize = g.MeasureString(item, label.Font);
					label.Size = new Size((int)textSize.Width - 4, (int)textSize.Height);
				}
			}
		}
		// Copied it from the .Designer file for the sake of completeness
		private void InitializeComponent()
		{
			this.contentPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SuspendLayout();
			// 
			// contentPanel
			// 
			this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.contentPanel.Location = new System.Drawing.Point(0, 0);
			this.contentPanel.Name = "contentPanel";
			this.contentPanel.Size = new System.Drawing.Size(150, 150);
			this.contentPanel.TabIndex = 0;
			// 
			// WordEditControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.contentPanel);
			this.Name = "WordEditControl";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.FlowLayoutPanel contentPanel;
	}
