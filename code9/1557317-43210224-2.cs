     public RelayCommand DeleteCommand
     {
        get
         {
            return new RelayCommand(p => Delete(p));
         }
     }
    public void Delete(string id)
    {
     //  DataTable.Rows.RemoveAt();
    }
