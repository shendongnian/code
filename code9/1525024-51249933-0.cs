    public class MyClass
    {
    public string ID { get; set; }
    public string Value { get; set; }
     
    }
     
    List<MyClass> myList = new List<MyClass>();
    var xrmOptionSet = new MyClass();
    xrmOptionSet.ID = "1";
    xrmOptionSet.Value = "100";
    var xrmOptionSet1 = new MyClass();
    xrmOptionSet1.ID = "2";
    xrmOptionSet1.Value = "200";
    var xrmOptionSet2 = new MyClass();
    xrmOptionSet2.ID = "1";
    xrmOptionSet2.Value = "100";
    myList.Add(xrmOptionSet);
    myList.Add(xrmOptionSet1);
    myList.Add(xrmOptionSet2);
     
    // here we are first grouping the result by label and then picking the first item from each group
    var myDistinctList = myList.GroupBy(i => i.ID)
    .Select(g => g.First()).ToList();
