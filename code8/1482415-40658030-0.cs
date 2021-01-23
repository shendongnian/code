    // old code
    public static ObservableCollection<Userss> userCol = new ObservableCollection<Userss>();
    
    // new Code
    private static ObservableCollection<Userss> userCol = new ObservableCollection<Userss>();
    
    public static ObservableCollection<Userss> UserCol {
       get { return userCol; }
       set { userCol = value; RaisePropertyChanged(); }
    }
