    public class TabViewModel
    {
    	public ObservableCollection<CostViewModel> ListViewSource { get; set; }
    	public ObservableCollection<TypeViewModel> ComboBoxSource { get; set; }
    
    	public TabViewModel()
    	{
    		ListViewSource = new ObservableCollection<CostViewModel>();
    		ListViewSource.Add(new CostViewModel() { CostA = "A", CostB = "B" });
    		ListViewSource.Add(new CostViewModel() { CostA = "1", CostB = "2" });            
    
    		ComboBoxSource = new ObservableCollection<TypeViewModel>();
    		ComboBoxSource.Add(new TypeViewModel() { TypeA = "A1", TypeB = "B1" });
    		ComboBoxSource.Add(new TypeViewModel() { TypeA = "A2", TypeB = "B2" });
    	}
    }
