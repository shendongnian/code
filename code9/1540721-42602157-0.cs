    DataTable dt = new DataTable();
    dt.Columns.Add("Name");                 // typeof(string) by default
    dt.Columns.Add("Count", typeof(int));   // specify numeric type
    dt.Rows.Add("Apple", 34);
    dt.Rows.Add("Apple", 12);
    dt.Rows.Add("Orange", 10);
    // to sum the Count only for Apple:
    int AppleCount = dt.Rows.Cast<DataRow>().Sum(r => "Apple".Equals(r[0]) ? (int)r[1] : 0); 
    // or group by Name if you need the Count of more than one Name
    var lookup = dt.Rows.Cast<DataRow>().ToLookup(r => r[0] as string, r => (int)r[1]);
    int iAppleCount = lookup["Apple"].Sum();    // 46
    int iOrangeCount = lookup["Orange"].Sum();  // 10
    // if Count is numeric tupe, you can also Compute them like this:
    var oAppleCount = dt.Compute("Sum(Count)", "Name = 'Apple'"); // 46 (object {long})
