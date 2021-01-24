    public RelayCommand NavigateToArticleCommand 
    { 
     get 
    { 
  
      return _navigateToArticleCommand
          ?? (_navigateToArticleCommand= new RelayCommand( 
            async () => 
            { 
              await SomeCommand(); 
            })); 
      } 
    }
