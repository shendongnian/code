    public class Form1 : Form
    {
        private readonly BindingList<string> _list1 = new BindingList<string>();
        private readonly BindingList<string> _list2 = new BindingList<string>();
        private readonly CompositeBindingList<string> _composite = new CompositeBindingList<string>();
        private readonly ViewModel _model = new ViewModel();
        class ViewModel : INotifyPropertyChanged
        {
            private int _index;
            public int Index
            {
                get { return _index; }
                set { _UpdateField(ref _index, value); }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void _UpdateField<T>(ref T field, T newValue,
                Action<T> onChangedCallback = null,
                [CallerMemberName] string propertyName = null)
            {
                if (EqualityComparer<T>.Default.Equals(field, newValue))
                {
                    return;
                }
                T oldValue = field;
                field = newValue;
                onChangedCallback?.Invoke(oldValue);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public Form1()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", _model, "Index", false, DataSourceUpdateMode.OnPropertyChanged);
            listBox1.DataSource = _list1;
            listBox2.DataSource = _list2;
            _composite.AddBindingList(_list1);
            _composite.AddBindingList(_list2);
            listBox3.DataSource = _composite;
            comboBox1.DataSource = _composite;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _list1.Add($"_list1: {_list1.Count + 1}");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _list2.Add($"_list2: {_list2.Count + 1}");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = _list2.Concat(_list1).ToArray();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            _composite.Insert(_model.Index, $"global: {_composite.Count + 1}");
        }
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.IntegralHeight = false;
            this.listBox1.ItemHeight = 31;
            this.listBox1.Location = new System.Drawing.Point(13, 72);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(315, 506);
            this.listBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 53);
            this.button2.TabIndex = 0;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.IntegralHeight = false;
            this.listBox2.ItemHeight = 31;
            this.listBox2.Location = new System.Drawing.Point(343, 71);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(315, 507);
            this.listBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(729, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(286, 39);
            this.comboBox1.TabIndex = 2;
            // 
            // listBox3
            // 
            this.listBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox3.FormattingEnabled = true;
            this.listBox3.IntegralHeight = false;
            this.listBox3.ItemHeight = 31;
            this.listBox3.Location = new System.Drawing.Point(674, 72);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(338, 506);
            this.listBox3.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(574, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 53);
            this.button3.TabIndex = 3;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 598);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(177, 52);
            this.button4.TabIndex = 4;
            this.button4.Text = "Add Global";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(195, 606);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 38);
            this.textBox1.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 660);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
    }
