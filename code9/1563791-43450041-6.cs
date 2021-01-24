    public partial class csvRow
    {
        public int Id { get; private set; }
        public string MenuName { get; private set; }
        public int? ParentId { get; private set; }
        public bool isHidden { get; private set; }
        public string LinkURL { get; private set; }
        public csvRow(string[] arr)
        {
            Id = Int32.Parse(arr[0]);
            MenuName = arr[1];
            //Parent Id can be null!
            ParentId = ToNullableInt(arr[2]);
            isHidden = bool.Parse(arr[3]);
            LinkURL = arr[4];
        }
        private static int? ToNullableInt(string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return i;
            else
                return null;
        }
    }
    static void Main(string[] args)
    {
        List<csvRow> unsortedRows = new List<csvRow>();
        // Read the file
        const string filePath = @"Navigation.csv";
        StreamReader sr = new StreamReader(File.OpenRead(filePath));
        string data = sr.ReadLine();
        //Read each line
        while (data != null)
        {
            var dataSplit = data.Split(';');   
            //We need to avoid parsing the first line. 
            if (dataSplit[0] != "ID" )
            {
                csvRow lis = new csvRow(dataSplit);
                unsortedRows.Add(lis);
            }
             // Break out of infinite loop
             data = sr.ReadLine();
          }
          sr.Dispose();
                
           //At this point we got our data in our List<csvRow> unsortedRows
           //It's parsed nicely. But we still need to sort it.
           //So let's get ourselves the root values. Those are the data entries that don't have a parent.
           //Please Note that the main method continues afterwards.
