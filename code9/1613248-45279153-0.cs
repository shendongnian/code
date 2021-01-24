    public partial class Form2 : Form
    {
    
        Form1 form1 = null;
    
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
            btnApply1.Click += new EventHandler(this.btnApply_Click);
            btnCancel1.Click += new EventHandler(this.btnCancel1_Click);
        }
    
        private void btnApply_Click(object sender, EventArgs e)
        {
            foreach (Process clsProcess in Process.GetProcesses())
            {
                if (clsProcess.ProcessName.Equals("EXCEL"))
                {
                clsProcess.Kill();
                break;
                }
            }
    
            new CRCCompareWorksheets.CompareHelper().ApplyChanges(form1.ExcelPath1.Text, form1.ExcelPath2.Text, "CRC");
        }
        private void btnCancel1_Click(object sender, EventArgs e)
        {
            new CRCCompareWorksheets.CompareHelper().CancelApplication();
        }
    }
