    private List<ClosingStockTemplateModel> moTemplatesToPrintList;
    private List<ClosingStockTemplateModel> moAvailableTemplates;
    
    public Form4()
    {
        InitializeComponent();
    
        this.moAvailableTemplates= new List<ClosingStockTemplateModel>()
        {
            new ClosingStockTemplateModel() {ID = 1, TEMPLATE ="Template 1" },
            new ClosingStockTemplateModel() {ID = 2, TEMPLATE ="Template 2" },
            new ClosingStockTemplateModel() {ID = 3, TEMPLATE ="Template 3" },
            new ClosingStockTemplateModel() {ID = 4, TEMPLATE ="Template 4" },
        };
    
        this.moTemplatesToPrintList = new List<ClosingStockTemplateModel>();
    
        this.grdAvailableTemplates.DataSource = this.moAvailableTemplates;
        this.grdTemplatesToPrint.DataSource = this.moTemplatesToPrintList;
    }
    
    private void cmdAdd_Click(object sender, EventArgs e)
    {
        var loGridViewAvailableTemplates = (this.grdAvailableTemplates.MainView as GridView);
        ClosingStockTemplateModel loClosingStockTemplateModel = loGridViewAvailableTemplates.GetRow(loGridViewAvailableTemplates.FocusedRowHandle) as ClosingStockTemplateModel;
    
        if (loClosingStockTemplateModel != null && 
            !this.moTemplatesToPrintList.Any(item => item.ID == loClosingStockTemplateModel.ID))
        {
            this.moTemplatesToPrintList.Add(loClosingStockTemplateModel);
            this.moAvailableTemplates.Remove(loClosingStockTemplateModel);
        }
        this.grdAvailableTemplates.RefreshDataSource();
        this.grdTemplatesToPrint.RefreshDataSource();
    }
    
    private void cmdRemove_Click(object sender, EventArgs e)
    {
        var loGridViewTemplatesToPrint = (this.grdTemplatesToPrint.MainView as GridView);
        ClosingStockTemplateModel loClosingStockTemplateModel = loGridViewTemplatesToPrint.GetRow(loGridViewTemplatesToPrint.FocusedRowHandle) as ClosingStockTemplateModel;
    
        if (loClosingStockTemplateModel != null &&
            !this.moAvailableTemplates.Any(item => item.ID == loClosingStockTemplateModel.ID))
        {
            this.moAvailableTemplates.Add(loClosingStockTemplateModel);
            this.moTemplatesToPrintList.Remove(loClosingStockTemplateModel);
        }
        this.grdAvailableTemplates.RefreshDataSource();
        this.grdTemplatesToPrint.RefreshDataSource();
    }
    }
    
    public class ClosingStockTemplateModel
    {
    public int ID { get; set; }
    public string TEMPLATE { get; set; }
    }
