    private bool _cb_3_checked;
    public bool CB_3_Checked 
    {
       get 
       {        
           if(CB_1_Checked && CB_2_Checked)
           {             
              _cb_3_checked = true; 
           }
           return _cb_3_checked;          
       }
       set
       {           
           _cb_3_checked = value;
           OnPropertyChanged();
       }
    }
