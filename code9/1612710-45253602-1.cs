    public class PerformanceForm
    {
    
    	public PerformanceForm()
    	{
    		// This call is required by the designer. 
    		InitializeComponent();
    		// Add any initialization after the InitializeComponent() call. 
    		PrimaryWeightNumsAr = {
    			num_Primary_Billing,
    			num_Primary_Rutine,
    			num_Primary_Seker,
    			num_Primary_Sla
    		};
    	}
    
    	private NumericUpDown[] PrimaryWeightNumsAr;
    	private void PrimaryWeightsValueChanged()
    	{
    
    		if (PrimaryWeightNumsAr == null)
    			return;
    		// do other stuff... 
    
    	}
    
    }
