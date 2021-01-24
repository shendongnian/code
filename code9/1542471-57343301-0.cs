    private ListBox listBox
    
    public MyClassViewModel(ListBox listBox)
    {
        this.listBox = listBox
    }
    
    public void MyMethod(){
        DateTime selectedDate = this.listBox.SelectedDate;
        
    }
