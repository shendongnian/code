    public int ID { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] // specify your date format here
    public DateTime DateOfBirth { get; set; }
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] // specify your date format here
    public DateTime DateOfArrival { get; set; }
