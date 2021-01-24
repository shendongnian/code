    public class DetailSelection
    {
        public DetailSelection() { }
        
        public Type SelectionType { get; set; }
        public string Description { get; set; }
        public int EnumValue { get; set; }
    }
    
    List<DetailSelection> details = new List<DetailSelection>();
    details.Add(new DetailSelection() {
        Description = "Color description",
        SelectionType = typeof(Color),
        EnumValue = Convert.ToInt32(Color.Black)
    });
    details.Add(new DetailSelection() {
        Description = "Day description",
        SelectionType = typeof(Day),
        EnumValue = Convert.ToInt32(Day.Wednesday)
    });
    details.Add(new DetailSelection() {
        Description = "Gender description",
        SelectionType = typeof(Gender),
        EnumValue = Convert.ToInt32(Gender.Male)
    });
    
    foreach (var detail in details)
    {
        var enumValue = Enum.Parse(detail.SelectionType, Convert.ToString(detail.EnumValue));
    
        Console.WriteLine(String.Format("Enum value: {0}", enumValue));
    }
    
    /* Output:
    Enum value: Black
    Enum value: Wednesday
    Enum value: Male
    */
