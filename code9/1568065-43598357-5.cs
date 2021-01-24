        RangeValidator1.MinimumValue = 0;
        RangeValidator1.MaximumValue = 10;
        RangeValidator1.Type = ValidationDataType.Integer;
        RangeValidator1.Validate();
    
        if (!RangeValidator1.IsValid)
        {
             if(Convert.ToInt32(text1.Text) < 0)
             {
                RangeValidator1.ErrorMessage = "number can not be less than 0";    
             }
             else
             {
                 RangeValidator1.ErrorMessage = "number can't be above maxvalue";    
             }    
        }
     
