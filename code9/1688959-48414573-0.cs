    public partial class frmStockList : Form
    {
        ServiceReference1.StockCardServicesClient stockList = new ServiceReference1.StockCardServicesClient();
        ServiceReference1.StockList stockDetails = new ServiceReference1.StockList();
    
        public frmStockList(frmMainForm mainForm)
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowStockListDetails();
        }
    
        private void ShowStockListDetails()
        {
            stockDetails.SearchIDNumber = frmMainForm.stockCardID.ToString();
    
            var StockList = stockList.GetParticularCard(stockDetails);
    
            stockDetails = StockList[0];
    
            BindingSource StockCardList = new BindingSource();
    
            StockCardList.ResetBindings(false);
    
            StockCardList.DataSource = stockDetails;
            
            txtID.DataBindings.Add(new Binding("Text", StockCardList, "CategoryName", true));
            txtOPCOID.DataBindings.Add(new Binding("Text", StockCardList, "MainGroupName", true));
            txtSubGroupID.DataBindings.Add(new Binding("Text", StockCardList, "SubGroupName", true));
            txtIDNumber.DataBindings.Add(new Binding("Text", StockCardList, "IDNumber", true));
            txtPartNumber.DataBindings.Add(new Binding("Text", StockCardList, "PartNumber", true));
            txtDescription.DataBindings.Add(new Binding("Text", StockCardList, "Description", true));
            txtMinimum.DataBindings.Add(new Binding("Text", StockCardList, "Minimum", true));
            txtMaximum.DataBindings.Add(new Binding("Text", StockCardList, "Maximum", true));
            cmbUOMPO.DataBindings.Add(new Binding("Text", StockCardList, "UOMPO", true));
            cmbUOMSTOCK.DataBindings.Add(new Binding("Text", StockCardList, "UOMStock", true));
            cmbUOMPERISSUE.DataBindings.Add(new Binding("Text", StockCardList, "UOMIssue", true));
            txtUOMRatio.DataBindings.Add(new Binding("Text", StockCardList, "UOMRatio", true));
            txtWidth.DataBindings.Add(new Binding("Text", StockCardList, "Width", true));
            txtHeight.DataBindings.Add(new Binding("Text", StockCardList, "Height", true));
            txtLength.DataBindings.Add(new Binding("Text", StockCardList, "Length", true));
            txtNetWeight.DataBindings.Add(new Binding("Text", StockCardList, "NetWeight", true));
            txtWarningExpiration.DataBindings.Add(new Binding("Text", StockCardList, "WarningPeriod", true));
            txtShelfLife.DataBindings.Add(new Binding("Text", StockCardList, "ShelfLife", true));
            txtCostCode.DataBindings.Add(new Binding("Text", StockCardList, "CostCodePurchase", true));
            cmbIssueToJob.DataBindings.Add(new Binding("Text", StockCardList, "CostCodeIssueToJob", true));
            cmbIssueToWS.DataBindings.Add(new Binding("Text", StockCardList, "CostCodeIssueToWS", true));
            cmbIssueToOPCO.DataBindings.Add(new Binding("Text", StockCardList, "CostCodeIssueToOPCO", true));
            cmbIssueForDisposalSCD.DataBindings.Add(new Binding("Text", StockCardList, "CostCodeIssueToDisposalSCD", true));
            cmbIssueForDisposalDMG.DataBindings.Add(new Binding("Text", StockCardList, "CostCodeIssueToDisposalDMG", true));
            cmbIssueForDisposalEXP.DataBindings.Add(new Binding("Text", StockCardList, "CostCodeIssueToDisposalEXP", true));
            cmbIssueForDisposalOBS.DataBindings.Add(new Binding("Text", StockCardList, "CostCodeIssueToDisposalOBS", true));
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            stockDetails.ID = frmMainForm.stockCardID.ToString();
    
            stockList.UpdateStockCard(stockDetails);
    
            MessageBox.Show("Update successfull!", "Update Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
            Dispose();
        }
    }
