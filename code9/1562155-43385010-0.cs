    private List<YourObject> gridData;          // List
    private BindingSource bindingSource;   
    public void Init()
    {
       this.gridData = new List<Anything>();
       //prefill list, in this case we want to have 100 empty rows in DataGrid
       for (var i = 0; i < 100; i++)
       {
          this.gridData.Add(new YourObject());
       }
       this.bindingSource.DataSource = this.gridData;
    }
    public void UpdateRow(int row)
    {
        this.gridData[row] = (from .. in select ...).FirstOrDefault(); // your query
    }
