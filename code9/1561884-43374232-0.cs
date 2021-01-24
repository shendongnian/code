    public class TravelTimeItem
    {
        public string From { get; set; }
        public YourType[] Times { get; set; }
    }
    public class YourType
    {
        public int Value { get; set; }
    }
    ...
    for (int i = 0; i < amountOfColumns; i++)
        grdTravelTime.Columns.Add(new DataGridTextColumn()
        {
            Binding = new Binding("Times[" + i.ToString() + "].Value"),
            Header = (i + 1).ToString()
        });
