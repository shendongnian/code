    public MyCommand New { get; private set; }
    public MyCommand Delete { get; private set; }
    public MyCommand ClearAll { get; private set; }
    public MyViewModelConstructor()
    {
        New = new MyCommand((parameter) =>
        {
            //Add new object
        });
        Delete = new MyCommand((parameter) =>
        {
            //Delete object
        });
        ClearAll = new MyCommand((parameter) =>
        {
            //Clear all objects
        });
    }
