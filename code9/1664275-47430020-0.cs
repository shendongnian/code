    //Define your first column at the class level;
    private OLVColumn colName;
    
    //Define InitColumns
    void InitColumns()
    {
        colName = new OLVColumn();
        colName.Name = "NameColumn";
        colName.Groupable = true;  //Make this groupable again, as we effectively override it.
        ...
        //Rest same as before
    }
    
    //In form_load
    private void Form1_Load(object sender, EventArgs e)
    {
        InitColumns();            
        ...
        //define your objects, same as before
    
        this.colName.GroupKeyGetter = delegate (object rowObject)
        {
            ModelObject item = (ModelObject)rowObject;
            return item.Age;
        };
    
        fastObjectListView1.ShowGroups = true;
        fastObjectListView1.Objects = modelObjects_;
    }
