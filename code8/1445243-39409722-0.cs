    declaration:
    // declare the List like this..
    
         ObservableCollection<string> ToAddToLBFilterStrings = new ObservableCollection<string>();
        
        
        if (_selectedString == "Project Managers")
                {
                    projectManagerItem.Visibility = Visibility.Visible;
        
                }
                elseif (_selectedString == "Structural Engineers")
                {
                    structEngItem.Visibility = Visibility.Visible;
                }
                elseif (_selectedString == "Service Engineers")
                {
                    servEngItem.Visibility = Visibility.Visible;
                }
    
            // Remove your Item here. And the List will be refreshed Automatically
              
                   ToAddToLBFilterStrings.Remove(_selectedString);
    
           
