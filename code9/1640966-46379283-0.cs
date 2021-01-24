    public Spinner spinner1;
    public Spinner spinner2;
    
    public enum Spinners {
    	Spinner1, Spinner2, None
    }
    
    public Types SelectedSpinner;
    public bool IsChangingSpinner;
    
    public void Init() {
    	SelectedSpinner = Spinners.None;
    	IsChangingSpinner = false;
    	
    	List<string> items = new List<string>();
    
    	//Populate dta into Items for Adapter
    	foreach(Data d in datas)
    	{
    		items.Add(d.ToString());
    	}
    
    	var adapter1 = new ArrayAdapter<string>(this, Resource.Layout.spinner_item, items);
    	adapter1.SetDropDownViewResource(Resource.Layout.spinner_item);
    	spinner1.Adapter = adapter;
    	spinner1.ItemSelected += spinner1_ItemSelected;
    	
    	var adapter2 = new ArrayAdapter<string>(this, Resource.Layout.spinner_item, items);
    	adapter2.SetDropDownViewResource(Resource.Layout.spinner_item);
    	spinner2.Adapter = adapter;
    	spinner2.ItemSelected += spinner2_ItemSelected;
    }
    
    
    public void spinner1_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {
    	if(IsChangingSpinner == false) {
    		Spinner spinner = (Spinner)sender;
    		string value = spinner.GetItemAtPosition(e.Position).ToString();
    		//Use value ...
    		
    		//Reset spinner2
    		IsChangingSpinner = true;
    		spinner2.SetSelection(0);
    		
    		if(SelectedSpinner == Spinners.Spinner1) {
    			IsChangingSpinner = false;
    		}
    		
    		SelectedSpinner = Spinners.Spinner1;
    		
    	} else {
    		IsChangingSpinner = false;
    	}
    }
    
    public void spinner2_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e) {
    	if(IsChangingSpinner == false) {
    		Spinner spinner = (Spinner)sender;
    		string value = spinner.GetItemAtPosition(e.Position).ToString();
    		//Use value ...
    		
    		//Reset spinner1
    		IsChangingSpinner = true;
    		spinner1.SetSelection(0);
    		
    		if(SelectedSpinner == Spinners.Spinner2) {
    			IsChangingSpinner = false;
    		}
    		
    		SelectedSpinner = Spinners.Spinner2;
    	} else {
    		IsChangingSpinner = false;
    	}
    	
    }
