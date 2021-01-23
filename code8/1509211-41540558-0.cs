    namespace SO
    {
        using System;
        using System.Windows.Forms;
    
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                var input = "11,22,33,44";
                string[] array = input.Split(',');
                dataGridView1.Rows.Add(array);
            }
        }
    }
