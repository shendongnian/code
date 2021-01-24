    private RelayCommand _closeCommand;
    public RelayCommand CloseCommand =>
         _closeCommand??(_closeCommand = 
        new RelayCommand(() =>{
           CloseFunc?.Close();
       })));
