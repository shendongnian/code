    public partial class EditableLabelControl : UserControl
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        public EditableLabelControl()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Visible = false;
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // EditableLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "EditableLabelControl";
            this.Size = new System.Drawing.Size(103, 23);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Visible = true;
            textBox1.BringToFront();
            textBox1.Focus();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text;
            textBox1.Visible = false;
            textBox1.SendToBack();
        }
    }
