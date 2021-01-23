    private RelayCommand<string> _updateNodeCategoryCommand ;
     public RelayCommand<string> UpdateNodeCategoryCommand { 
    get { return _updateNodeCategoryCommand ?? (_updateNodeCategoryCommand = new RelayCommand<string>( nodeCategory => { NodeCategory=nodeCategory })); 
    }
     }
